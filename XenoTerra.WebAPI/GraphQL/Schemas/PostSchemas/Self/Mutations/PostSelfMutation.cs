using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.PostServices;
using XenoTerra.DTOLayer.Dtos.PostDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.PostMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class PostSelfMutation
    {
        public async Task<CreatePostSelfPayload> CreateMyPostAsync(
            [Service] IPostSelfMutationService mutationService,
            [Service] IPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreatePostSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreatePostSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreatePostSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreatePostSelfInput, CreatePostDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreatePostSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdatePostSelfPayload> UpdateMyPostAsync(
            [Service] IPostSelfMutationService mutationService,
            [Service] IPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdatePostSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdatePostSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdatePostSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdatePostSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdatePostSelfInput, UpdatePostDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdatePostSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeletePostSelfPayload> DeleteMyPostAsync(
            [Service] IPostSelfMutationService mutationService,
            [Service] IPostReadService readService,
            [Service] IPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var post = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (post.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeletePostSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendPostEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultPostDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(PostSelfSubscription.OnPostSelfCreated),
                        PostSelfCreatedEvent.From<PostSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(PostSelfSubscription.OnPostSelfUpdated),
                        PostSelfUpdatedEvent.From<PostSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(PostSelfSubscription.OnPostSelfDeleted),
                        PostSelfDeletedEvent.From<PostSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(PostSelfSubscription.OnPostSelfChanged),
                PostSelfChangedEvent.From<PostSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}


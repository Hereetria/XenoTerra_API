using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Own.PostMutationServices;
using XenoTerra.DTOLayer.Dtos.PostAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.PostServices.Write.Own;
using XenoTerra.BussinessLogicLayer.Services.Entity.PostServices.Read;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class PostOwnMutation
    {
        public async Task<CreatePostOwnPayload> CreateOwnPostAsync(
            [Service] IPostOwnMutationService mutationService,
            [Service] IPostOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreatePostOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreatePostOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreatePostOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreatePostOwnInput, CreatePostOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreatePostOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdatePostOwnPayload> UpdateOwnPostAsync(
            [Service] IPostOwnMutationService mutationService,
            [Service] IPostOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdatePostOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdatePostOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdatePostOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdatePostOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdatePostOwnInput, UpdatePostOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdatePostOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeletePostOwnPayload> DeleteOwnPostAsync(
            [Service] IPostOwnMutationService mutationService,
            [Service] IPostReadService readService,
            [Service] IPostOwnWriteService writeService,
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

            var payload = await mutationService.DeleteAsync<DeletePostOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendPostEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendPostEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultPostOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(PostOwnSubscription.OnPostOwnCreated),
                        PostOwnCreatedEvent.From<PostOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(PostOwnSubscription.OnPostOwnUpdated),
                        PostOwnUpdatedEvent.From<PostOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(PostOwnSubscription.OnPostOwnDeleted),
                        PostOwnDeletedEvent.From<PostOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(PostOwnSubscription.OnPostOwnChanged),
                PostOwnChangedEvent.From<PostOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}


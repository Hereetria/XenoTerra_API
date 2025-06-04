using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.DTOLayer.Dtos.PostLikeDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.PostLikeMutationServices;
using XenoTerra.BussinessLogicLayer.Services.Entity.PostLikeServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class PostLikeSelfMutation
    {
        public async Task<CreatePostLikeSelfPayload> CreateMyLikeAsync(
            [Service] IPostLikeSelfMutationService mutationService,
            [Service] IPostLikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreatePostLikeSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreatePostLikeSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreatePostLikeSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreatePostLikeSelfInput, CreatePostLikeDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreatePostLikeSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdatePostLikeSelfPayload> UpdateMyLikeAsync(
            [Service] IPostLikeSelfMutationService mutationService,
            [Service] IPostLikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdatePostLikeSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdatePostLikeSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdatePostLikeSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdatePostLikeSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdatePostLikeSelfInput, UpdatePostLikeDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdatePostLikeSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeletePostLikeSelfPayload> DeleteMyLikeAsync(
            [Service] IPostLikeSelfMutationService mutationService,
            [Service] IPostLikeReadService readService,
            [Service] IPostLikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var like = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (like.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeletePostLikeSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendLikeEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultPostLikeDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(PostLikeSelfSubscription.OnLikeSelfCreated),
                        PostLikeSelfCreatedEvent.From<PostLikeSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(PostLikeSelfSubscription.OnLikeSelfUpdated),
                        PostLikeSelfUpdatedEvent.From<PostLikeSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(PostLikeSelfSubscription.OnLikeSelfDeleted),
                        PostLikeSelfDeletedEvent.From<PostLikeSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(PostLikeSelfSubscription.OnLikeSelfChanged),
                PostLikeSelfChangedEvent.From<PostLikeSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}


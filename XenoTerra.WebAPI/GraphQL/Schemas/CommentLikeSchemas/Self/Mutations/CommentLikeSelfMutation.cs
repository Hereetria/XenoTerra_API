using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.CommentLikeMutationServices;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentLikeServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class CommentLikeSelfMutation
    {
        public async Task<CreateCommentLikeSelfPayload> CreateMyLikeAsync(
            [Service] ICommentLikeSelfMutationService mutationService,
            [Service] ICommentLikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateCommentLikeSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateCommentLikeSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateCommentLikeSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateCommentLikeSelfInput, CreateCommentLikeDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateCommentLikeSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateCommentLikeSelfPayload> UpdateMyLikeAsync(
            [Service] ICommentLikeSelfMutationService mutationService,
            [Service] ICommentLikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateCommentLikeSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateCommentLikeSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateCommentLikeSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateCommentLikeSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateCommentLikeSelfInput, UpdateCommentLikeDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateCommentLikeSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteCommentLikeSelfPayload> DeleteMyLikeAsync(
            [Service] ICommentLikeSelfMutationService mutationService,
            [Service] ICommentLikeReadService readService,
            [Service] ICommentLikeWriteService writeService,
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

            var payload = await mutationService.DeleteAsync<DeleteCommentLikeSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendLikeEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultCommentLikeDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(CommentLikeSelfSubscription.OnLikeSelfCreated),
                        CommentLikeSelfCreatedEvent.From<CommentLikeSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(CommentLikeSelfSubscription.OnLikeSelfUpdated),
                        CommentLikeSelfUpdatedEvent.From<CommentLikeSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(CommentLikeSelfSubscription.OnLikeSelfDeleted),
                        CommentLikeSelfDeletedEvent.From<CommentLikeSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(CommentLikeSelfSubscription.OnLikeSelfChanged),
                CommentLikeSelfChangedEvent.From<CommentLikeSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}


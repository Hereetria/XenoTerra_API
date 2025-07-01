using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations.Inputs;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentLikeServices.Read;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentLikeServices.Write.Own;
using XenoTerra.DTOLayer.Dtos.CommentLikeDtos.Self.Own;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.CommentLikeMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class CommentLikeOwnMutation
    {
        public async Task<CreateCommentLikeOwnPayload> CreateOwnCommentLikeAsync(
            [Service] ICommentLikeOwnMutationService mutationService,
            [Service] ICommentLikeOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateCommentLikeOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateCommentLikeOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateCommentLikeOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateCommentLikeOwnInput, CreateCommentLikeOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateCommentLikeOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateCommentLikeOwnPayload> UpdateOwnCommentLikeAsync(
            [Service] ICommentLikeOwnMutationService mutationService,
            [Service] ICommentLikeOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateCommentLikeOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateCommentLikeOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateCommentLikeOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateCommentLikeOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateCommentLikeOwnInput, UpdateCommentLikeOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.UpdateAsync<UpdateCommentLikeOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteCommentLikeOwnPayload> DeleteOwnCommentLikeAsync(
            [Service] ICommentLikeOwnMutationService mutationService,
            [Service] ICommentLikeReadService readService,
            [Service] ICommentLikeOwnWriteService writeService,
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

            var payload = await mutationService.DeleteAsync<DeleteCommentLikeOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendLikeEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultCommentLikeOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(CommentLikeOwnSubscription.OnLikeOwnCreated),
                        CommentLikeOwnCreatedEvent.From<CommentLikeOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(CommentLikeOwnSubscription.OnLikeOwnUpdated),
                        CommentLikeOwnUpdatedEvent.From<CommentLikeOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(CommentLikeOwnSubscription.OnLikeOwnDeleted),
                        CommentLikeOwnDeletedEvent.From<CommentLikeOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(CommentLikeOwnSubscription.OnLikeOwnChanged),
                CommentLikeOwnChangedEvent.From<CommentLikeOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}


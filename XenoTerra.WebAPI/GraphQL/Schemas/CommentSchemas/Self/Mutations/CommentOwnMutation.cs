using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Own.CommentMutationServices;
using XenoTerra.DTOLayer.Dtos.CommentAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Mutations.Inputs;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentServices.Read;
using XenoTerra.BussinessLogicLayer.Services.Entity.CommentServices.Write.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class CommentOwnMutation
    {
        public async Task<CreateCommentOwnPayload> CreateOwnCommentAsync(
            [Service] ICommentOwnMutationService mutationService,
            [Service] ICommentOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateCommentOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateCommentOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateCommentOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateCommentOwnInput, CreateCommentOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateCommentOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateCommentOwnPayload> UpdateOwnCommentAsync(
            [Service] ICommentOwnMutationService mutationService,
            [Service] ICommentOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateCommentOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateCommentOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateCommentOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateCommentOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateCommentOwnInput, UpdateCommentOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateCommentOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteCommentOwnPayload> DeleteOwnCommentAsync(
            [Service] ICommentOwnMutationService mutationService,
            [Service] ICommentReadService readService,
            [Service] ICommentOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var comment = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (comment.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteCommentOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendCommentEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendCommentEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultCommentOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(CommentOwnSubscription.OnCommentOwnCreated),
                        CommentOwnCreatedEvent.From<CommentOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(CommentOwnSubscription.OnCommentOwnUpdated),
                        CommentOwnUpdatedEvent.From<CommentOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(CommentOwnSubscription.OnCommentOwnDeleted),
                        CommentOwnDeletedEvent.From<CommentOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(CommentOwnSubscription.OnCommentOwnChanged),
                CommentOwnChangedEvent.From<CommentOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}
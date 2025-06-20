using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Own.MessageMutationServices;
using XenoTerra.DTOLayer.Dtos.MessageAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations.Inputs;
using XenoTerra.BussinessLogicLayer.Services.Entity.MessageServices.Read;
using XenoTerra.BussinessLogicLayer.Services.Entity.MessageServices.Write.Own;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class MessageOwnMutation
    {
        public async Task<CreateMessageOwnPayload> CreateOwnMessageAsync(
            [Service] IMessageOwnMutationService mutationService,
            [Service] IMessageOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateMessageOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateMessageOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateMessageOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateMessageOwnInput, CreateMessageOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.SenderId = userId;

            var payload = await mutationService.CreateAsync<CreateMessageOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendMessageEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateMessageOwnPayload> UpdateOwnMessageAsync(
            [Service] IMessageOwnMutationService mutationService,
            [Service] IMessageOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateMessageOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateMessageOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateMessageOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateMessageOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateMessageOwnInput, UpdateMessageOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.SenderId = userId;

            var payload = await mutationService.UpdateAsync<UpdateMessageOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendMessageEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteMessageOwnPayload> DeleteOwnMessageAsync(
            [Service] IMessageOwnMutationService mutationService,
            [Service] IMessageReadService readService,
            [Service] IMessageOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var message = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.ReceiverId
            );

            if (message.ReceiverId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteMessageOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendMessageEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendMessageEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultMessageOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(MessageOwnSubscription.OnMessageOwnCreated),
                        MessageOwnCreatedEvent.From<MessageOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(MessageOwnSubscription.OnMessageOwnUpdated),
                        MessageOwnUpdatedEvent.From<MessageOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(MessageOwnSubscription.OnMessageOwnDeleted),
                        MessageOwnDeletedEvent.From<MessageOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(MessageOwnSubscription.OnMessageOwnChanged),
                MessageOwnChangedEvent.From<MessageOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}


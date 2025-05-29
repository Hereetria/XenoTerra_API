using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.MessageServices;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.MessageMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class MessageSelfMutation
    {
        public async Task<CreateMessageSelfPayload> CreateMyMessageAsync(
            [Service] IMessageSelfMutationService mutationService,
            [Service] IMessageWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateMessageSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateMessageSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateMessageSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateMessageSelfInput, CreateMessageDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.SenderId = userId;

            var payload = await mutationService.CreateAsync<CreateMessageSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendMessageEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateMessageSelfPayload> UpdateMyMessageAsync(
            [Service] IMessageSelfMutationService mutationService,
            [Service] IMessageWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateMessageSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateMessageSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateMessageSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateMessageSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateMessageSelfInput, UpdateMessageDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.SenderId = userId;

            var payload = await mutationService.UpdateAsync<UpdateMessageSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendMessageEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteMessageSelfPayload> DeleteMyMessageAsync(
            [Service] IMessageSelfMutationService mutationService,
            [Service] IMessageReadService readService,
            [Service] IMessageWriteService writeService,
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

            var payload = await mutationService.DeleteAsync<DeleteMessageSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendMessageEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendMessageEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultMessageDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(MessageSelfSubscription.OnMessageSelfCreated),
                        MessageSelfCreatedEvent.From<MessageSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(MessageSelfSubscription.OnMessageSelfUpdated),
                        MessageSelfUpdatedEvent.From<MessageSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(MessageSelfSubscription.OnMessageSelfDeleted),
                        MessageSelfDeletedEvent.From<MessageSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(MessageSelfSubscription.OnMessageSelfChanged),
                MessageSelfChangedEvent.From<MessageSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}


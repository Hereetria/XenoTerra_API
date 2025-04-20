using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.MessageService;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.MessageMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.MessageMutations
{
    public class MessageMutation
    {
        public async Task<CreateMessagePayload> CreateMessageAsync(
            [Service] IMessageMutationService mutationService,
            [Service] IMessageWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateMessageInput? input)
        {
            if (!InputValidator.ValidateInputFields<Message, CreateMessageInput, ResultMessageDto, CreateMessagePayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateMessageInput, CreateMessageDto>(input);
            var payload = await mutationService.CreateAsync<CreateMessagePayload>(writeService, createDto);

            await SendMessageCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateMessagePayload> UpdateMessageAsync(
            [Service] IMessageMutationService mutationService,
            [Service] IMessageWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateMessageInput? input)
        {
            if (!InputValidator.ValidateInputFields<Message, UpdateMessageInput, ResultMessageDto, UpdateMessagePayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateMessageInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateMessageInput, UpdateMessageDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateMessagePayload>(writeService, updateDto, modifiedFields);

            await SendMessageUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteMessagePayload> DeleteMessageAsync(
            [Service] IMessageMutationService mutationService,
            [Service] IMessageWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<Message, ResultMessageDto, DeleteMessagePayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteMessagePayload>(writeService, parsedKey);

            await SendMessageDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendMessageCreatedEvents(ITopicEventSender sender, ResultMessageDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(MessageSubscription.OnMessageCreated),
                MessageCreatedEvent.From<MessageCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(MessageSubscription.OnMessageChanged),
                MessageChangedEvent.From<MessageChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendMessageUpdatedEvents(ITopicEventSender sender, ResultMessageDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(MessageSubscription.OnMessageUpdated),
                MessageUpdatedEvent.From<MessageUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(MessageSubscription.OnMessageChanged),
                MessageChangedEvent.From<MessageChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendMessageDeletedEvents(ITopicEventSender sender, ResultMessageDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(MessageSubscription.OnMessageDeleted),
                MessageDeletedEvent.From<MessageDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(MessageSubscription.OnMessageChanged),
                MessageChangedEvent.From<MessageChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}

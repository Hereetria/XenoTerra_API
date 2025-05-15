using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.MessageService;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.MessageMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations
{
    public class MessageMutation
    {
        public async Task<CreateMessagePayload> CreateMessageAsync(
            [Service] IMessageMutationService mutationService,
            [Service] IMessageWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateMessageInput> inputValidator,
            CreateMessageInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateMessageInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateMessageInput, CreateMessageDto>(input);
            var payload = await mutationService.CreateAsync<CreateMessagePayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendMessageEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateMessagePayload> UpdateMessageAsync(
            [Service] IMessageMutationService mutationService,
            [Service] IMessageWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateMessageInput> inputValidator,
            IResolverContext context,
            UpdateMessageInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateMessageInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateMessageInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateMessageInput, UpdateMessageDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateMessagePayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendMessageEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteMessagePayload> DeleteMessageAsync(
            [Service] IMessageMutationService mutationService,
            [Service] IMessageWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteMessagePayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendMessageEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendMessageEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultMessageDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(MessageSubscription.OnMessageCreated),
                        MessageCreatedEvent.From<MessageCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(MessageSubscription.OnMessageUpdated),
                        MessageUpdatedEvent.From<MessageUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(MessageSubscription.OnMessageDeleted),
                        MessageDeletedEvent.From<MessageDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(MessageSubscription.OnMessageChanged),
                MessageChangedEvent.From<MessageChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

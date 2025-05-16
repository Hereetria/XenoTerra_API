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
    public class MessageSelfMutation
    {
        public async Task<CreateMessageSelfPayload> CreateMessageAsync(
            [Service] IMessageMutationService mutationService,
            [Service] IMessageWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateMessageSelfInput> inputSelfValidator,
            CreateMessageSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateMessageSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateMessageSelfInput, CreateMessageDto>(input);
            var payload = await mutationService.CreateAsync<CreateMessageSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendMessageEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateMessageSelfPayload> UpdateMessageAsync(
            [Service] IMessageMutationService mutationService,
            [Service] IMessageWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateMessageSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateMessageSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateMessageSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateMessageSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateMessageSelfInput, UpdateMessageDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateMessageSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendMessageEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteMessageSelfPayload> DeleteMessageAsync(
            [Service] IMessageMutationService mutationService,
            [Service] IMessageWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteMessageSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(MessageSelfSubscription.OnMessageCreated),
                        MessageCreatedSelfEvent.From<MessageCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(MessageSelfSubscription.OnMessageUpdated),
                        MessageUpdatedSelfEvent.From<MessageUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(MessageSelfSubscription.OnMessageDeleted),
                        MessageDeletedSelfEvent.From<MessageDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(MessageSelfSubscription.OnMessageChanged),
                MessageChangedSelfEvent.From<MessageChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

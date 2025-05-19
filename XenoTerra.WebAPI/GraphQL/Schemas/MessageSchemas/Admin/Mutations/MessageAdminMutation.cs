using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.MessageServices;
using XenoTerra.DTOLayer.Dtos.MessageDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.MessageMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class MessageAdminMutation
    {
        public async Task<CreateMessageAdminPayload> CreateMessageAsync(
            [Service] IMessageAdminMutationService mutationService,
            [Service] IMessageWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateMessageAdminInput> inputAdminValidator,
            CreateMessageAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateMessageAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateMessageAdminInput, CreateMessageDto>(input);
            var payload = await mutationService.CreateAsync<CreateMessageAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendMessageEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateMessageAdminPayload> UpdateMessageAsync(
            [Service] IMessageAdminMutationService mutationService,
            [Service] IMessageWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateMessageAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateMessageAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateMessageAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateMessageAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateMessageAdminInput, UpdateMessageDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateMessageAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendMessageEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteMessageAdminPayload> DeleteMessageAsync(
            [Service] IMessageAdminMutationService mutationService,
            [Service] IMessageWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteMessageAdminPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(MessageAdminSubscription.OnMessageAdminCreated),
                        MessageAdminCreatedEvent.From<MessageAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(MessageAdminSubscription.OnMessageAdminUpdated),
                        MessageAdminUpdatedEvent.From<MessageAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(MessageAdminSubscription.OnMessageAdminDeleted),
                        MessageAdminDeletedEvent.From<MessageAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(MessageAdminSubscription.OnMessageAdminChanged),
                MessageAdminChangedEvent.From<MessageAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

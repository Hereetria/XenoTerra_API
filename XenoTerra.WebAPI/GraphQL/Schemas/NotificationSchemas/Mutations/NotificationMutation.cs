using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.NotificationService;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.NotificationMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Mutations
{
    public class NotificationMutation
    {
        public async Task<CreateNotificationPayload> CreateNotificationAsync(
            [Service] INotificationMutationService mutationService,
            [Service] INotificationWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateNotificationInput> inputValidator,
            CreateNotificationInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateNotificationInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateNotificationInput, CreateNotificationDto>(input);
            var payload = await mutationService.CreateAsync<CreateNotificationPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateNotificationPayload> UpdateNotificationAsync(
            [Service] INotificationMutationService mutationService,
            [Service] INotificationWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateNotificationInput> inputValidator,
            IResolverContext context,
            UpdateNotificationInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateNotificationInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateNotificationInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateNotificationInput, UpdateNotificationDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateNotificationPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteNotificationPayload> DeleteNotificationAsync(
            [Service] INotificationMutationService mutationService,
            [Service] INotificationWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteNotificationPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendNotificationEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultNotificationDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(NotificationSubscription.OnNotificationCreated),
                        NotificationCreatedEvent.From<NotificationCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(NotificationSubscription.OnNotificationUpdated),
                        NotificationUpdatedEvent.From<NotificationUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(NotificationSubscription.OnNotificationDeleted),
                        NotificationDeletedEvent.From<NotificationDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(NotificationSubscription.OnNotificationChanged),
                NotificationChangedEvent.From<NotificationChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

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
            IResolverContext context,
            CreateNotificationInput? input)
        {
            if (!InputValidator.ValidateInputFields<Notification, CreateNotificationInput, ResultNotificationDto, CreateNotificationPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateNotificationInput, CreateNotificationDto>(input);
            var payload = await mutationService.CreateAsync<CreateNotificationPayload>(writeService, createDto);

            await SendNotificationCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateNotificationPayload> UpdateNotificationAsync(
            [Service] INotificationMutationService mutationService,
            [Service] INotificationWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateNotificationInput? input)
        {
            if (!InputValidator.ValidateInputFields<Notification, UpdateNotificationInput, ResultNotificationDto, UpdateNotificationPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateNotificationInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateNotificationInput, UpdateNotificationDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateNotificationPayload>(writeService, updateDto, modifiedFields);

            await SendNotificationUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteNotificationPayload> DeleteNotificationAsync(
            [Service] INotificationMutationService mutationService,
            [Service] INotificationWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<Notification, ResultNotificationDto, DeleteNotificationPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteNotificationPayload>(writeService, parsedKey);

            await SendNotificationDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendNotificationCreatedEvents(ITopicEventSender sender, ResultNotificationDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(NotificationSubscription.OnNotificationCreated),
                NotificationCreatedEvent.From<NotificationCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(NotificationSubscription.OnNotificationChanged),
                NotificationChangedEvent.From<NotificationChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendNotificationUpdatedEvents(ITopicEventSender sender, ResultNotificationDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(NotificationSubscription.OnNotificationUpdated),
                NotificationUpdatedEvent.From<NotificationUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(NotificationSubscription.OnNotificationChanged),
                NotificationChangedEvent.From<NotificationChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendNotificationDeletedEvents(ITopicEventSender sender, ResultNotificationDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(NotificationSubscription.OnNotificationDeleted),
                NotificationDeletedEvent.From<NotificationDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(NotificationSubscription.OnNotificationChanged),
                NotificationChangedEvent.From<NotificationChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}

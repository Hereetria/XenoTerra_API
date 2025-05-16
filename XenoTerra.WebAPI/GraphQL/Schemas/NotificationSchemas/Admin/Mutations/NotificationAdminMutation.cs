using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.NotificationService;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.NotificationMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations
{
    public class NotificationAdminMutation
    {
        public async Task<CreateNotificationAdminPayload> CreateNotificationAsync(
            [Service] INotificationMutationService mutationService,
            [Service] INotificationWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateNotificationAdminInput> inputAdminValidator,
            CreateNotificationAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateNotificationAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateNotificationAdminInput, CreateNotificationDto>(input);
            var payload = await mutationService.CreateAsync<CreateNotificationAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateNotificationAdminPayload> UpdateNotificationAsync(
            [Service] INotificationMutationService mutationService,
            [Service] INotificationWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateNotificationAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateNotificationAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateNotificationAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateNotificationAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateNotificationAdminInput, UpdateNotificationDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateNotificationAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteNotificationAdminPayload> DeleteNotificationAsync(
            [Service] INotificationMutationService mutationService,
            [Service] INotificationWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteNotificationAdminPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(NotificationAdminSubscription.OnNotificationCreated),
                        NotificationCreatedAdminEvent.From<NotificationCreatedAdminEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(NotificationAdminSubscription.OnNotificationUpdated),
                        NotificationUpdatedAdminEvent.From<NotificationUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(NotificationAdminSubscription.OnNotificationDeleted),
                        NotificationDeletedAdminEvent.From<NotificationDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(NotificationAdminSubscription.OnNotificationChanged),
                NotificationChangedAdminEvent.From<NotificationChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

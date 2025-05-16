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
    public class NotificationSelfMutation
    {
        public async Task<CreateNotificationSelfPayload> CreateNotificationAsync(
            [Service] INotificationMutationService mutationService,
            [Service] INotificationWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateNotificationSelfInput> inputSelfValidator,
            CreateNotificationSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateNotificationSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateNotificationSelfInput, CreateNotificationDto>(input);
            var payload = await mutationService.CreateAsync<CreateNotificationSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateNotificationSelfPayload> UpdateNotificationAsync(
            [Service] INotificationMutationService mutationService,
            [Service] INotificationWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateNotificationSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateNotificationSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateNotificationSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateNotificationSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateNotificationSelfInput, UpdateNotificationDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateNotificationSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteNotificationSelfPayload> DeleteNotificationAsync(
            [Service] INotificationMutationService mutationService,
            [Service] INotificationWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteNotificationSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(NotificationSelfSubscription.OnNotificationCreated),
                        NotificationCreatedSelfEvent.From<NotificationCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(NotificationSelfSubscription.OnNotificationUpdated),
                        NotificationUpdatedSelfEvent.From<NotificationUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(NotificationSelfSubscription.OnNotificationDeleted),
                        NotificationDeletedSelfEvent.From<NotificationDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(NotificationSelfSubscription.OnNotificationChanged),
                NotificationChangedSelfEvent.From<NotificationChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

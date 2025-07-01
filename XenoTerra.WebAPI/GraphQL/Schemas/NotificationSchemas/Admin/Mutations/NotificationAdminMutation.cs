using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.NotificationMutationServices;
using XenoTerra.BussinessLogicLayer.Services.Entity.NotificationServices.Write.Admin;
using XenoTerra.DTOLayer.Dtos.NotificationDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class NotificationAdminMutation
    {
        public async Task<CreateNotificationAdminPayload> CreateNotificationAsync(
            [Service] INotificationAdminMutationService mutationService,
            [Service] INotificationAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateNotificationAdminInput> inputAdminValidator,
            CreateNotificationAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateNotificationAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateNotificationAdminInput, CreateNotificationAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreateNotificationAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateNotificationAdminPayload> UpdateNotificationAsync(
            [Service] INotificationAdminMutationService mutationService,
            [Service] INotificationAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateNotificationAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateNotificationAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateNotificationAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateNotificationAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateNotificationAdminInput, UpdateNotificationAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateNotificationAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteNotificationAdminPayload> DeleteNotificationAsync(
            [Service] INotificationAdminMutationService mutationService,
            [Service] INotificationAdminWriteService writeService,
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
            ResultNotificationAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(NotificationAdminSubscription.OnNotificationAdminCreated),
                        NotificationAdminCreatedEvent.From<NotificationAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(NotificationAdminSubscription.OnNotificationAdminUpdated),
                        NotificationAdminUpdatedEvent.From<NotificationAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(NotificationAdminSubscription.OnNotificationAdminDeleted),
                        NotificationAdminDeletedEvent.From<NotificationAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(NotificationAdminSubscription.OnNotificationAdminChanged),
                NotificationAdminChangedEvent.From<NotificationAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

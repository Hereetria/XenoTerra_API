using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Own.NotificationMutationServices;
using XenoTerra.DTOLayer.Dtos.NotificationAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.NotificationServices.Write.Own;
using XenoTerra.BussinessLogicLayer.Services.Entity.NotificationServices.Read;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class NotificationOwnMutation
    {
        public async Task<CreateNotificationOwnPayload> CreateOwnNotificationAsync(
            [Service] INotificationOwnMutationService mutationService,
            [Service] INotificationOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateNotificationOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateNotificationOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateNotificationOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateNotificationOwnInput, CreateNotificationOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateNotificationOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateNotificationOwnPayload> UpdateOwnNotificationAsync(
            [Service] INotificationOwnMutationService mutationService,
            [Service] INotificationOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateNotificationOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateNotificationOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateNotificationOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateNotificationOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateNotificationOwnInput, UpdateNotificationOwnDto>(input, modifiedFields);
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateNotificationOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteNotificationOwnPayload> DeleteOwnNotificationAsync(
            [Service] INotificationOwnMutationService mutationService,
            [Service] INotificationReadService readService,
            [Service] INotificationOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var notification = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (notification.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteNotificationOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendNotificationEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultNotificationOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(NotificationOwnSubscription.OnNotificationOwnCreated),
                        NotificationOwnCreatedEvent.From<NotificationOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(NotificationOwnSubscription.OnNotificationOwnUpdated),
                        NotificationOwnUpdatedEvent.From<NotificationOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(NotificationOwnSubscription.OnNotificationOwnDeleted),
                        NotificationOwnDeletedEvent.From<NotificationOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(NotificationOwnSubscription.OnNotificationOwnChanged),
                NotificationOwnChangedEvent.From<NotificationOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}


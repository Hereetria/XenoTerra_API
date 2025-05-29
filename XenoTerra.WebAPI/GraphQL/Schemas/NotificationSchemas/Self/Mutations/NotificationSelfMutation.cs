using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.NotificationServices;
using XenoTerra.DTOLayer.Dtos.NotificationDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.NotificationMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class NotificationSelfMutation
    {
        public async Task<CreateNotificationSelfPayload> CreateMyNotificationAsync(
            [Service] INotificationSelfMutationService mutationService,
            [Service] INotificationWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateNotificationSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateNotificationSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateNotificationSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateNotificationSelfInput, CreateNotificationDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateNotificationSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateNotificationSelfPayload> UpdateMyNotificationAsync(
            [Service] INotificationSelfMutationService mutationService,
            [Service] INotificationWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateNotificationSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateNotificationSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateNotificationSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateNotificationSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateNotificationSelfInput, UpdateNotificationDto>(input, modifiedFields);
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateNotificationSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteNotificationSelfPayload> DeleteMyNotificationAsync(
            [Service] INotificationSelfMutationService mutationService,
            [Service] INotificationReadService readService,
            [Service] INotificationWriteService writeService,
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

            var payload = await mutationService.DeleteAsync<DeleteNotificationSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendNotificationEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }
        private async Task SendNotificationEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultNotificationDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(NotificationSelfSubscription.OnNotificationSelfCreated),
                        NotificationSelfCreatedEvent.From<NotificationSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(NotificationSelfSubscription.OnNotificationSelfUpdated),
                        NotificationSelfUpdatedEvent.From<NotificationSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(NotificationSelfSubscription.OnNotificationSelfDeleted),
                        NotificationSelfDeletedEvent.From<NotificationSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(NotificationSelfSubscription.OnNotificationSelfChanged),
                NotificationSelfChangedEvent.From<NotificationSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}


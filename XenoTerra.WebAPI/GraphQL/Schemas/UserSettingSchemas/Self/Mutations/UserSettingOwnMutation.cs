using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Own.UserSettingMutationServices;
using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Self.Own;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations.Inputs;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingServices.Write.Own;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingServices.Read;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class UserSettingOwnMutation
    {
        public async Task<CreateUserSettingOwnPayload> CreateOwnUserSettingAsync(
            [Service] IUserSettingOwnMutationService mutationService,
            [Service] IUserSettingOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateUserSettingOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateUserSettingOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateUserSettingOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateUserSettingOwnInput, CreateUserSettingOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateUserSettingOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendUserSettingEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateUserSettingOwnPayload> UpdateOwnUserSettingAsync(
            [Service] IUserSettingOwnMutationService mutationService,
            [Service] IUserSettingOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateUserSettingOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateUserSettingOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserSettingOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserSettingOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserSettingOwnInput, UpdateUserSettingOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateUserSettingOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserSettingEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserSettingOwnPayload> DeleteOwnUserSettingAsync(
            [Service] IUserSettingOwnMutationService mutationService,
            [Service] IUserSettingReadService readService,
            [Service] IUserSettingOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var userSetting = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.UserId
            );

            if (userSetting.UserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteUserSettingOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendUserSettingEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }

        private async Task SendUserSettingEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultUserSettingOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;


            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(UserSettingOwnSubscription.OnUserSettingOwnCreated),
                        UserSettingOwnCreatedEvent.From<UserSettingOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(UserSettingOwnSubscription.OnUserSettingOwnUpdated),
                        UserSettingOwnUpdatedEvent.From<UserSettingOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(UserSettingOwnSubscription.OnUserSettingOwnDeleted),
                        UserSettingOwnDeletedEvent.From<UserSettingOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(UserSettingOwnSubscription.OnUserSettingOwnChanged),
                UserSettingOwnChangedEvent.From<UserSettingOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}


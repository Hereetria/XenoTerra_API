using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingServices;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.UserSettingMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class UserSettingSelfMutation
    {
        public async Task<CreateUserSettingSelfPayload> CreateMyUserSettingAsync(
            [Service] IUserSettingSelfMutationService mutationService,
            [Service] IUserSettingWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateUserSettingSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateUserSettingSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateUserSettingSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateUserSettingSelfInput, CreateUserSettingDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateUserSettingSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendUserSettingEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateUserSettingSelfPayload> UpdateMyUserSettingAsync(
            [Service] IUserSettingSelfMutationService mutationService,
            [Service] IUserSettingWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateUserSettingSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateUserSettingSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserSettingSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserSettingSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserSettingSelfInput, UpdateUserSettingDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateUserSettingSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserSettingEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserSettingSelfPayload> DeleteMyUserSettingAsync(
            [Service] IUserSettingSelfMutationService mutationService,
            [Service] IUserSettingReadService readService,
            [Service] IUserSettingWriteService writeService,
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

            var payload = await mutationService.DeleteAsync<DeleteUserSettingSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendUserSettingEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }

        private async Task SendUserSettingEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultUserSettingDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;


            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(UserSettingSelfSubscription.OnUserSettingSelfCreated),
                        UserSettingSelfCreatedEvent.From<UserSettingSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(UserSettingSelfSubscription.OnUserSettingSelfUpdated),
                        UserSettingSelfUpdatedEvent.From<UserSettingSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(UserSettingSelfSubscription.OnUserSettingSelfDeleted),
                        UserSettingSelfDeletedEvent.From<UserSettingSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(UserSettingSelfSubscription.OnUserSettingSelfChanged),
                UserSettingSelfChangedEvent.From<UserSettingSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}


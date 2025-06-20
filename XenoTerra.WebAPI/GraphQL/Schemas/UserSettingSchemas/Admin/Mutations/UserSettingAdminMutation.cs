using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.UserSettingMutationServices;
using XenoTerra.DTOLayer.Dtos.UserSettingAdminDtos.Admin;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingServices.Write.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class UserSettingAdminMutation
    {
        public async Task<CreateUserSettingAdminPayload> CreateUserSettingAsync(
            [Service] IUserSettingAdminMutationService mutationService,
            [Service] IUserSettingAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateUserSettingAdminInput> inputAdminValidator,
            CreateUserSettingAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateUserSettingAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateUserSettingAdminInput, CreateUserSettingAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreateUserSettingAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendUserSettingEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateUserSettingAdminPayload> UpdateUserSettingAsync(
            [Service] IUserSettingAdminMutationService mutationService,
            [Service] IUserSettingAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateUserSettingAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateUserSettingAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserSettingAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserSettingAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserSettingAdminInput, UpdateUserSettingAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateUserSettingAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserSettingEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserSettingAdminPayload> DeleteUserSettingAsync(
            [Service] IUserSettingAdminMutationService mutationService,
            [Service] IUserSettingAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteUserSettingAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendUserSettingEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendUserSettingEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultUserSettingAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(UserSettingAdminSubscription.OnUserSettingAdminCreated),
                        UserSettingAdminCreatedEvent.From<UserSettingAdminCreatedEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(UserSettingAdminSubscription.OnUserSettingAdminUpdated),
                        UserSettingAdminUpdatedEvent.From<UserSettingAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(UserSettingAdminSubscription.OnUserSettingAdminDeleted),
                        UserSettingAdminDeletedEvent.From<UserSettingAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(UserSettingAdminSubscription.OnUserSettingAdminChanged),
                UserSettingAdminChangedEvent.From<UserSettingAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

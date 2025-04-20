using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserSettingService;
using XenoTerra.DTOLayer.Dtos.UserSettingDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.UserSettingMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Mutations
{
    public class UserSettingMutation
    {
        public async Task<CreateUserSettingPayload> CreateUserSettingAsync(
            [Service] IUserSettingMutationService mutationService,
            [Service] IUserSettingWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateUserSettingInput? input)
        {
            if (!InputValidator.ValidateInputFields<UserSetting, CreateUserSettingInput, ResultUserSettingDto, CreateUserSettingPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateUserSettingInput, CreateUserSettingDto>(input);
            var payload = await mutationService.CreateAsync<CreateUserSettingPayload>(writeService, createDto);

            await SendUserSettingCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateUserSettingPayload> UpdateUserSettingAsync(
            [Service] IUserSettingMutationService mutationService,
            [Service] IUserSettingWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateUserSettingInput? input)
        {
            if (!InputValidator.ValidateInputFields<UserSetting, UpdateUserSettingInput, ResultUserSettingDto, UpdateUserSettingPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserSettingInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserSettingInput, UpdateUserSettingDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateUserSettingPayload>(writeService, updateDto, modifiedFields);

            await SendUserSettingUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserSettingPayload> DeleteUserSettingAsync(
            [Service] IUserSettingMutationService mutationService,
            [Service] IUserSettingWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<UserSetting, ResultUserSettingDto, DeleteUserSettingPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteUserSettingPayload>(writeService, parsedKey);

            await SendUserSettingDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendUserSettingCreatedEvents(ITopicEventSender sender, ResultUserSettingDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(UserSettingSubscription.OnUserSettingCreated),
                UserSettingCreatedEvent.From<UserSettingCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(UserSettingSubscription.OnUserSettingChanged),
                UserSettingChangedEvent.From<UserSettingChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendUserSettingUpdatedEvents(ITopicEventSender sender, ResultUserSettingDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(UserSettingSubscription.OnUserSettingUpdated),
                UserSettingUpdatedEvent.From<UserSettingUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(UserSettingSubscription.OnUserSettingChanged),
                UserSettingChangedEvent.From<UserSettingChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendUserSettingDeletedEvents(ITopicEventSender sender, ResultUserSettingDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(UserSettingSubscription.OnUserSettingDeleted),
                UserSettingDeletedEvent.From<UserSettingDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(UserSettingSubscription.OnUserSettingChanged),
                UserSettingChangedEvent.From<UserSettingChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}

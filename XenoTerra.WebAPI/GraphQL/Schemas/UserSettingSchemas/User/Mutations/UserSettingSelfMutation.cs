using FluentValidation;
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
    public class UserSettingSelfMutation
    {
        public async Task<CreateUserSettingSelfPayload> CreateUserSettingAsync(
            [Service] IUserSettingMutationService mutationService,
            [Service] IUserSettingWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateUserSettingSelfInput> inputSelfValidator,
            CreateUserSettingSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateUserSettingSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateUserSettingSelfInput, CreateUserSettingDto>(input);
            var payload = await mutationService.CreateAsync<CreateUserSettingSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendUserSettingEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateUserSettingSelfPayload> UpdateUserSettingAsync(
            [Service] IUserSettingMutationService mutationService,
            [Service] IUserSettingWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateUserSettingSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateUserSettingSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserSettingSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserSettingSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserSettingSelfInput, UpdateUserSettingDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateUserSettingSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserSettingEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserSettingSelfPayload> DeleteUserSettingAsync(
            [Service] IUserSettingMutationService mutationService,
            [Service] IUserSettingWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteUserSettingSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendUserSettingEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendUserSettingEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultUserSettingDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(UserSettingSelfSubscription.OnUserSettingCreated),
                        UserSettingCreatedSelfEvent.From<UserSettingCreatedSelfEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(UserSettingSelfSubscription.OnUserSettingUpdated),
                        UserSettingUpdatedSelfEvent.From<UserSettingUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(UserSettingSelfSubscription.OnUserSettingDeleted),
                        UserSettingDeletedSelfEvent.From<UserSettingDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(UserSettingSelfSubscription.OnUserSettingChanged),
                UserSettingChangedSelfEvent.From<UserSettingChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

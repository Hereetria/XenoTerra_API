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
    public class UserSettingMutation
    {
        public async Task<CreateUserSettingPayload> CreateUserSettingAsync(
            [Service] IUserSettingMutationService mutationService,
            [Service] IUserSettingWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateUserSettingInput> inputValidator,
            CreateUserSettingInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateUserSettingInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateUserSettingInput, CreateUserSettingDto>(input);
            var payload = await mutationService.CreateAsync<CreateUserSettingPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendUserSettingEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateUserSettingPayload> UpdateUserSettingAsync(
            [Service] IUserSettingMutationService mutationService,
            [Service] IUserSettingWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateUserSettingInput> inputValidator,
            IResolverContext context,
            UpdateUserSettingInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateUserSettingInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserSettingInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserSettingInput, UpdateUserSettingDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateUserSettingPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendUserSettingEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserSettingPayload> DeleteUserSettingAsync(
            [Service] IUserSettingMutationService mutationService,
            [Service] IUserSettingWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteUserSettingPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(UserSettingSubscription.OnUserSettingCreated),
                        UserSettingCreatedEvent.From<UserSettingCreatedEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(UserSettingSubscription.OnUserSettingUpdated),
                        UserSettingUpdatedEvent.From<UserSettingUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(UserSettingSubscription.OnUserSettingDeleted),
                        UserSettingDeletedEvent.From<UserSettingDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(UserSettingSubscription.OnUserSettingChanged),
                UserSettingChangedEvent.From<UserSettingChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

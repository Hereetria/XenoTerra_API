using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserService;
using XenoTerra.DTOLayer.Dtos.UserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.UserMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Mutations
{
    public class UserMutation
    {
        public async Task<CreateUserPayload> CreateUserAsync(
            [Service] IUserMutationService mutationService,
            [Service] IUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateUserInput? input)
        {
            if (!InputValidator.ValidateInputFields<User, CreateUserInput, ResultUserDto, CreateUserPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateUserInput, CreateUserDto>(input);
            var payload = await mutationService.CreateAsync<CreateUserPayload>(writeService, createDto);

            await SendUserCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateUserPayload> UpdateUserAsync(
            [Service] IUserMutationService mutationService,
            [Service] IUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateUserInput? input)
        {
            if (!InputValidator.ValidateInputFields<User, UpdateUserInput, ResultUserDto, UpdateUserPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserInput, UpdateUserDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateUserPayload>(writeService, updateDto, modifiedFields);

            await SendUserUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserPayload> DeleteUserAsync(
            [Service] IUserMutationService mutationService,
            [Service] IUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<User, ResultUserDto, DeleteUserPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteUserPayload>(writeService, parsedKey);

            await SendUserDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendUserCreatedEvents(ITopicEventSender sender, ResultUserDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(UserSubscription.OnUserCreated),
                UserCreatedEvent.From<UserCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(UserSubscription.OnUserChanged),
                UserChangedEvent.From<UserChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendUserUpdatedEvents(ITopicEventSender sender, ResultUserDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(UserSubscription.OnUserUpdated),
                UserUpdatedEvent.From<UserUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(UserSubscription.OnUserChanged),
                UserChangedEvent.From<UserChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendUserDeletedEvents(ITopicEventSender sender, ResultUserDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(UserSubscription.OnUserDeleted),
                UserDeletedEvent.From<UserDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(UserSubscription.OnUserChanged),
                UserChangedEvent.From<UserChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}

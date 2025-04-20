using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.UserPostTagServices;
using XenoTerra.DTOLayer.Dtos.UserPostTagDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.UserPostTagMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Mutations
{
    public class UserPostTagMutation
    {
        public async Task<CreateUserPostTagPayload> CreateUserPostTagAsync(
            [Service] IUserPostTagMutationService mutationService,
            [Service] IUserPostTagWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateUserPostTagInput? input)
        {
            if (!InputValidator.ValidateInputFields<UserPostTag, CreateUserPostTagInput, ResultUserPostTagDto, CreateUserPostTagPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateUserPostTagInput, CreateUserPostTagDto>(input);
            var payload = await mutationService.CreateAsync<CreateUserPostTagPayload>(writeService, createDto);

            await SendUserPostTagCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateUserPostTagPayload> UpdateUserPostTagAsync(
            [Service] IUserPostTagMutationService mutationService,
            [Service] IUserPostTagWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateUserPostTagInput? input)
        {
            if (!InputValidator.ValidateInputFields<UserPostTag, UpdateUserPostTagInput, ResultUserPostTagDto, UpdateUserPostTagPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateUserPostTagInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateUserPostTagInput, UpdateUserPostTagDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateUserPostTagPayload>(writeService, updateDto, modifiedFields);

            await SendUserPostTagUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteUserPostTagPayload> DeleteUserPostTagAsync(
            [Service] IUserPostTagMutationService mutationService,
            [Service] IUserPostTagWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<UserPostTag, ResultUserPostTagDto, DeleteUserPostTagPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteUserPostTagPayload>(writeService, parsedKey);

            await SendUserPostTagDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendUserPostTagCreatedEvents(ITopicEventSender sender, ResultUserPostTagDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(UserPostTagSubscription.OnUserPostTagCreated),
                UserPostTagCreatedEvent.From<UserPostTagCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(UserPostTagSubscription.OnUserPostTagChanged),
                UserPostTagChangedEvent.From<UserPostTagChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendUserPostTagUpdatedEvents(ITopicEventSender sender, ResultUserPostTagDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(UserPostTagSubscription.OnUserPostTagUpdated),
                UserPostTagUpdatedEvent.From<UserPostTagUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(UserPostTagSubscription.OnUserPostTagChanged),
                UserPostTagChangedEvent.From<UserPostTagChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendUserPostTagDeletedEvents(ITopicEventSender sender, ResultUserPostTagDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(UserPostTagSubscription.OnUserPostTagDeleted),
                UserPostTagDeletedEvent.From<UserPostTagDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(UserPostTagSubscription.OnUserPostTagChanged),
                UserPostTagChangedEvent.From<UserPostTagChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}

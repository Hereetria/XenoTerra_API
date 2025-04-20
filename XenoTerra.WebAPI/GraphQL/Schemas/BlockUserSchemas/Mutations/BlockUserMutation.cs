using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Models;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.BlockUserMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations
{
    public class BlockUserMutation
    {
        public async Task<CreateBlockUserPayload> CreateBlockUserAsync(
            [Service] IBlockUserMutationService mutationService,
            [Service] IBlockUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateBlockUserInput? input)
        {
            if (!InputValidator.ValidateInputFields<BlockUser, CreateBlockUserInput, ResultBlockUserDto, CreateBlockUserPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateBlockUserInput, CreateBlockUserDto>(input);
            var payload = await mutationService.CreateAsync<CreateBlockUserPayload>(writeService, createDto);

            await SendBlockUserCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateBlockUserPayload> UpdateBlockUserAsync(
            [Service] IBlockUserMutationService mutationService,
            [Service] IBlockUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateBlockUserInput? input)
        {
            if (!InputValidator.ValidateInputFields<BlockUser, UpdateBlockUserInput, ResultBlockUserDto, UpdateBlockUserPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateBlockUserInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateBlockUserInput, UpdateBlockUserDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateBlockUserPayload>(writeService, updateDto, modifiedFields);

            await SendBlockUserUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteBlockUserPayload> DeleteBlockUserAsync(
            [Service] IBlockUserMutationService mutationService,
            [Service] IBlockUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<BlockUser, ResultBlockUserDto, DeleteBlockUserPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteBlockUserPayload>(writeService, parsedKey);

            await SendBlockUserDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendBlockUserCreatedEvents(ITopicEventSender sender, ResultBlockUserDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(BlockUserSubscription.OnBlockUserCreated),
                BlockUserCreatedEvent.From<BlockUserCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(BlockUserSubscription.OnBlockUserChanged),
                BlockUserChangedEvent.From<BlockUserChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendBlockUserUpdatedEvents(ITopicEventSender sender, ResultBlockUserDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(BlockUserSubscription.OnBlockUserUpdated),
                BlockUserUpdatedEvent.From<BlockUserUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(BlockUserSubscription.OnBlockUserChanged),
                BlockUserChangedEvent.From<BlockUserChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendBlockUserDeletedEvents(ITopicEventSender sender, ResultBlockUserDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(BlockUserSubscription.OnBlockUserDeleted),
                BlockUserDeletedEvent.From<BlockUserDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(BlockUserSubscription.OnBlockUserChanged),
                BlockUserChangedEvent.From<BlockUserChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}

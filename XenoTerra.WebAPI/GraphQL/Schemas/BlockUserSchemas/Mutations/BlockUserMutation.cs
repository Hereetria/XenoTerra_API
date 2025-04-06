using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Models;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Services.Mutations.Entity.BlockUserMutationServices;
using XenoTerra.WebAPI.Utils;

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
            var payloadEntityResult = payload.Result!;

            var createdEvent = BlockUserCreatedEvent.From<BlockUserCreatedEvent>(
                payloadEntityResult,
                Guid.NewGuid(),
                DateTime.UtcNow
            );

            var changedEvent = BlockUserChangedEvent.From<BlockUserChangedEvent>(
                ChangedEventType.Created,
                payloadEntityResult,
                Guid.NewGuid(),
                DateTime.UtcNow
            );

            await eventSender.SendAsync(nameof(BlockUserSubscription.OnBlockUserCreated), createdEvent);
            await eventSender.SendAsync(nameof(BlockUserSubscription.OnBlockUserChanged), changedEvent);

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
            var payloadEntityResult = payload.Result!;

            var updatedEvent = BlockUserUpdatedEvent.From<BlockUserUpdatedEvent>(
                payloadEntityResult,
                Guid.NewGuid(),
                DateTime.UtcNow,
                modifiedFields
            );

            var changedEvent = BlockUserChangedEvent.From<BlockUserChangedEvent>(
                ChangedEventType.Updated,
                payloadEntityResult,
                Guid.NewGuid(),
                DateTime.UtcNow,
                modifiedFields
            );

            await eventSender.SendAsync(nameof(BlockUserSubscription.OnBlockUserUpdated), updatedEvent);
            await eventSender.SendAsync(nameof(BlockUserSubscription.OnBlockUserChanged), changedEvent);

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
            var payloadEntityResult = payload.Result!;

            var deletedEvent = BlockUserDeletedEvent.From<BlockUserDeletedEvent>(
                payloadEntityResult,
                Guid.NewGuid(),
                DateTime.UtcNow
            );

            var changedEvent = BlockUserChangedEvent.From<BlockUserChangedEvent>(
                ChangedEventType.Deleted,
                payloadEntityResult,
                Guid.NewGuid(),
                DateTime.UtcNow
            );

            await eventSender.SendAsync(nameof(BlockUserSubscription.OnBlockUserDeleted), deletedEvent);
            await eventSender.SendAsync(nameof(BlockUserSubscription.OnBlockUserChanged), changedEvent);

            return payload;
        }
    }
}

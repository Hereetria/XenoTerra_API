using FluentValidation;
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
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
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
            [Service] IValidator<CreateBlockUserInput> inputValidator,
            CreateBlockUserInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateBlockUserInput));

            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateBlockUserInput, CreateCommentckUserDto>(input);
            var payload = await mutationService.CreateAsync<CreateBlockUserPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateBlockUserPayload> UpdateBlockUserAsync(
            [Service] IBlockUserMutationService mutationService,
            [Service] IBlockUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateBlockUserInput> inputValidator,
            IResolverContext context,
            UpdateBlockUserInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateBlockUserInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateBlockUserInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateBlockUserInput, UpdateBlockUserDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateBlockUserPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteBlockUserPayload> DeleteBlockUserAsync(
            [Service] IBlockUserMutationService mutationService,
            [Service] IBlockUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteBlockUserPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendBlockUserEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultBlockUserDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(BlockUserSubscription.OnBlockUserCreated),
                        BlockUserCreatedEvent.From<BlockUserCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(BlockUserSubscription.OnBlockUserUpdated),
                        BlockUserUpdatedEvent.From<BlockUserUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(BlockUserSubscription.OnBlockUserDeleted),
                        BlockUserDeletedEvent.From<BlockUserDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(BlockUserSubscription.OnBlockUserChanged),
                BlockUserChangedEvent.From<BlockUserChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

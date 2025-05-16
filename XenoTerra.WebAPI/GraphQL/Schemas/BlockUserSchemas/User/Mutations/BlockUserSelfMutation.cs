using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserService;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.BlockUserMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations
{
    public class BlockUserSelfMutation
    {
        public async Task<CreateBlockUserSelfPayload> CreateBlockUserAsync(
            [Service] IBlockUserMutationService mutationService,
            [Service] IBlockUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateBlockUserSelfInput> inputSelfValidator,
            CreateBlockUserSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateBlockUserSelfInput));

            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateBlockUserSelfInput, CreateCommentckUserDto>(input);
            var payload = await mutationService.CreateAsync<CreateBlockUserSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateBlockUserSelfPayload> UpdateBlockUserAsync(
            [Service] IBlockUserMutationService mutationService,
            [Service] IBlockUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateBlockUserSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateBlockUserSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateBlockUserSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateBlockUserSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateBlockUserSelfInput, UpdateBlockUserDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateBlockUserSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteBlockUserSelfPayload> DeleteBlockUserAsync(
            [Service] IBlockUserMutationService mutationService,
            [Service] IBlockUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteBlockUserSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(BlockUserSelfSubscription.OnBlockUserCreated),
                        BlockUserCreatedSelfEvent.From<BlockUserCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(BlockUserSelfSubscription.OnBlockUserUpdated),
                        BlockUserUpdatedSelfEvent.From<BlockUserUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(BlockUserSelfSubscription.OnBlockUserDeleted),
                        BlockUserDeletedSelfEvent.From<BlockUserDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(BlockUserSelfSubscription.OnBlockUserChanged),
                BlockUserChangedSelfEvent.From<BlockUserChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

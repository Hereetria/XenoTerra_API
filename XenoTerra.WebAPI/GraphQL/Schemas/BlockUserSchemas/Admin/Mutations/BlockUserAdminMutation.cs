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
    public class BlockUserAdminMutation
    {
        public async Task<CreateBlockUserAdminPayload> CreateBlockUserAsync(
            [Service] IBlockUserMutationService mutationService,
            [Service] IBlockUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateBlockUserAdminInput> inputAdminValidator,
            CreateBlockUserAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateBlockUserAdminInput));

            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateBlockUserAdminInput, CreateCommentckUserDto>(input);
            var payload = await mutationService.CreateAsync<CreateBlockUserAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateBlockUserAdminPayload> UpdateBlockUserAsync(
            [Service] IBlockUserMutationService mutationService,
            [Service] IBlockUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateBlockUserAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateBlockUserAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateBlockUserAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateBlockUserAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateBlockUserAdminInput, UpdateBlockUserDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateBlockUserAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteBlockUserAdminPayload> DeleteBlockUserAsync(
            [Service] IBlockUserMutationService mutationService,
            [Service] IBlockUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteBlockUserAdminPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(BlockUserAdminSubscription.OnBlockUserCreated),
                        BlockUserCreatedAdminEvent.From<BlockUserCreatedAdminEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(BlockUserAdminSubscription.OnBlockUserUpdated),
                        BlockUserUpdatedAdminEvent.From<BlockUserUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(BlockUserAdminSubscription.OnBlockUserDeleted),
                        BlockUserDeletedAdminEvent.From<BlockUserDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(BlockUserAdminSubscription.OnBlockUserChanged),
                BlockUserChangedAdminEvent.From<BlockUserChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

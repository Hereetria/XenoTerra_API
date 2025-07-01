using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.BlockUserAdminMutationServices;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserServices.Write.Admin;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class BlockUserAdminMutation
    {
        public async Task<CreateBlockUserAdminPayload> CreateBlockUserAsync(
            [Service] IBlockUserAdminMutationService mutationService,
            [Service] IBlockUserAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateBlockUserAdminInput> inputAdminValidator,
            CreateBlockUserAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateBlockUserAdminInput));

            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateBlockUserAdminInput, CreateBlockUserAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreateBlockUserAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateBlockUserAdminPayload> UpdateBlockUserAsync(
            [Service] IBlockUserAdminMutationService mutationService,
            [Service] IBlockUserAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateBlockUserAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateBlockUserAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateBlockUserAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateBlockUserAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateBlockUserAdminInput, UpdateBlockUserAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateBlockUserAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteBlockUserAdminPayload> DeleteBlockUserAsync(
            [Service] IBlockUserAdminMutationService mutationService,
            [Service] IBlockUserAdminWriteService writeService,
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
            ResultBlockUserAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(BlockUserAdminSubscription.OnBlockUserAdminCreated),
                        BlockUserAdminCreatedEvent.From<BlockUserAdminCreatedEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(BlockUserAdminSubscription.OnBlockUserAdminUpdated),
                        BlockUserAdminUpdatedEvent.From<BlockUserAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(BlockUserAdminSubscription.OnBlockUserAdminDeleted),
                        BlockUserAdminDeletedEvent.From<BlockUserAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(BlockUserAdminSubscription.OnBlockUserAdminChanged),
                BlockUserAdminChangedEvent.From<BlockUserAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

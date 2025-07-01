using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Http;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Mutations.Inputs;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserServices.Write.Own;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserServices.Read;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos.Self.Own;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.BlockUserMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class BlockUserOwnMutation
    {
        public async Task<CreateBlockUserOwnPayload> CreateOwnBlockUserAsync(
            [Service] IBlockUserOwnMutationService mutationService,
            [Service] IBlockUserOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateBlockUserOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateBlockUserOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateBlockUserOwnInput));

            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateBlockUserOwnInput, CreateBlockUserOwnDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.BlockingUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.CreateAsync<CreateBlockUserOwnPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateBlockUserOwnPayload> UpdateOwnBlockUserAsync(
            [Service] IBlockUserOwnMutationService mutationService,
            [Service] IBlockUserOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateBlockUserOwnInput> inputOwnValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateBlockUserOwnInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateBlockUserOwnInput));
            await ValidationGuard.ValidateOrThrowAsync(inputOwnValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateBlockUserOwnInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateBlockUserOwnInput, UpdateBlockUserOwnDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.BlockingUserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateBlockUserOwnPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteBlockUserOwnPayload> DeleteOwnBlockUserAsync(
            [Service] IBlockUserOwnMutationService mutationService,
            [Service] IBlockUserReadService readService,
            [Service] IBlockUserOwnWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var blockUser = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.BlockingUserId
            );

            if (blockUser.BlockingUserId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this block."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteBlockUserOwnPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
            {
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);
            }

            return payload;
        }

        private async Task SendBlockUserEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultBlockUserOwnDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(BlockUserOwnSubscription.OnBlockUserOwnCreated),
                        BlockUserOwnCreatedEvent.From<BlockUserOwnCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(BlockUserOwnSubscription.OnBlockUserOwnUpdated),
                        BlockUserOwnUpdatedEvent.From<BlockUserOwnUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(BlockUserOwnSubscription.OnBlockUserOwnDeleted),
                        BlockUserOwnDeletedEvent.From<BlockUserOwnDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(BlockUserOwnSubscription.OnBlockUserOwnChanged),
                BlockUserOwnChangedEvent.From<BlockUserOwnChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

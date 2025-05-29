using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Http;
using XenoTerra.BussinessLogicLayer.Services.Entity.BlockUserServices;
using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.GraphQL.Types.PayloadTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.BlockUserSelfMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class BlockUserSelfMutation
    {
        public async Task<CreateBlockUserSelfPayload> CreateMyBlockUserAsync(
            [Service] IBlockUserSelfMutationService mutationService,
            [Service] IBlockUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateBlockUserSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateBlockUserSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateBlockUserSelfInput));

            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateBlockUserSelfInput, CreateCommentckUserDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.BlockingUserId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.CreateAsync<CreateBlockUserSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateBlockUserSelfPayload> UpdateMyBlockUserAsync(
            [Service] IBlockUserSelfMutationService mutationService,
            [Service] IBlockUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateBlockUserSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateBlockUserSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateBlockUserSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateBlockUserSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateBlockUserSelfInput, UpdateBlockUserDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.BlockingUserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateBlockUserSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteBlockUserSelfPayload> DeleteMyBlockUserAsync(
            [Service] IBlockUserSelfMutationService mutationService,
            [Service] IBlockUserReadService readService,
            [Service] IBlockUserWriteService writeService,
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

            var payload = await mutationService.DeleteAsync<DeleteBlockUserSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
            {
                await SendBlockUserEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);
            }

            return payload;
        }

        private async Task SendBlockUserEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultBlockUserDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(BlockUserSelfSubscription.OnBlockUserSelfCreated),
                        BlockUserSelfCreatedEvent.From<BlockUserSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(BlockUserSelfSubscription.OnBlockUserSelfUpdated),
                        BlockUserSelfUpdatedEvent.From<BlockUserSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(BlockUserSelfSubscription.OnBlockUserSelfDeleted),
                        BlockUserSelfDeletedEvent.From<BlockUserSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(BlockUserSelfSubscription.OnBlockUserSelfChanged),
                BlockUserSelfChangedEvent.From<BlockUserSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

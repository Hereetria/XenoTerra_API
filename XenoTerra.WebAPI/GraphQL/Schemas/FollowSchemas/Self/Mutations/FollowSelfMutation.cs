using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.FollowServices;
using XenoTerra.DTOLayer.Dtos.FollowDtos;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.FollowMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class FollowSelfMutation
    {
        public async Task<CreateFollowSelfPayload> CreateMyFollowAsync(
            [Service] IFollowSelfMutationService mutationService,
            [Service] IFollowWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateFollowSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateFollowSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateFollowSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var createDto = DtoMapperHelper.MapInputToDto<CreateFollowSelfInput, CreateFollowDto>(input);
            createDto.FollowerId = userId;

            var payload = await mutationService.CreateAsync<CreateFollowSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateFollowSelfPayload> UpdateMyFollowAsync(
            [Service] IFollowSelfMutationService mutationService,
            [Service] IFollowWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateFollowSelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateFollowSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateFollowSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateFollowSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateFollowSelfInput, UpdateFollowDto>(input, modifiedFields);
            updateDto.FollowerId = userId;

            var payload = await mutationService.UpdateAsync<UpdateFollowSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteFollowSelfPayload> DeleteMyFollowAsync(
            [Service] IFollowSelfMutationService mutationService,
            [Service] IFollowReadService readService,
            [Service] IFollowWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var follow = EntityReadHelper.FetchEntityWithSelectedFieldsOrThrow(
                readService,
                parsedKey,
                x => x.FollowerId
            );

            if (follow.FollowerId != userId)
            {
                throw GraphQLExceptionFactory.Create(
                    "Access denied.",
                    ["You are not authorized to delete this entity."],
                    "UNAUTHORIZED"
                );
            }

            var payload = await mutationService.DeleteAsync<DeleteFollowSelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendFollowEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }

        private async Task SendFollowEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultFollowDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(FollowSelfSubscription.OnFollowSelfCreated),
                        FollowSelfCreatedEvent.From<FollowSelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(FollowSelfSubscription.OnFollowSelfUpdated),
                        FollowSelfUpdatedEvent.From<FollowSelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(FollowSelfSubscription.OnFollowSelfDeleted),
                        FollowSelfDeletedEvent.From<FollowSelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(FollowSelfSubscription.OnFollowSelfChanged),
                FollowSelfChangedEvent.From<FollowSelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}


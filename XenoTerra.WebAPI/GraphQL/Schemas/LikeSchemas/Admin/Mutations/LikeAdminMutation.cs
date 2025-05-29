using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.LikeServices;
using XenoTerra.DTOLayer.Dtos.LikeDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.LikeMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class LikeAdminMutation
    {
        public async Task<CreateLikeAdminPayload> CreateLikeAsync(
            [Service] ILikeAdminMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateLikeAdminInput> inputAdminValidator,
            CreateLikeAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateLikeAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateLikeAdminInput, CreateLikeDto>(input);
            var payload = await mutationService.CreateAsync<CreateLikeAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateLikeAdminPayload> UpdateLikeAsync(
            [Service] ILikeAdminMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateLikeAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateLikeAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateLikeAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateLikeAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateLikeAdminInput, UpdateLikeDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateLikeAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteLikeAdminPayload> DeleteLikeAsync(
            [Service] ILikeAdminMutationService mutationService,
            [Service] ILikeWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteLikeAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendLikeEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendLikeEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultLikeDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(LikeAdminSubscription.OnLikeAdminCreated),
                        LikeAdminCreatedEvent.From<LikeAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(LikeAdminSubscription.OnLikeAdminUpdated),
                        LikeAdminUpdatedEvent.From<LikeAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(LikeAdminSubscription.OnLikeAdminDeleted),
                        LikeAdminDeletedEvent.From<LikeAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(LikeAdminSubscription.OnLikeAdminChanged),
                LikeAdminChangedEvent.From<LikeAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

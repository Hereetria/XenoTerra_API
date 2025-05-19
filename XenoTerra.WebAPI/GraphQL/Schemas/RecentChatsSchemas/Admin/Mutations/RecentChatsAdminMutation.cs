using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.RecentChatsServices;
using XenoTerra.DTOLayer.Dtos.RecentChatsDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.RecentChatsMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class RecentChatsAdminMutation
    {
        public async Task<CreateRecentChatsAdminPayload> CreateRecentChatsAsync(
            [Service] IRecentChatsAdminMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateRecentChatsAdminInput> inputAdminValidator,
            CreateRecentChatsAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateRecentChatsAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateRecentChatsAdminInput, CreateRecentChatsDto>(input);
            var payload = await mutationService.CreateAsync<CreateRecentChatsAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateRecentChatsAdminPayload> UpdateRecentChatsAsync(
            [Service] IRecentChatsAdminMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateRecentChatsAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateRecentChatsAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateRecentChatsAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateRecentChatsAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateRecentChatsAdminInput, UpdateRecentChatsDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateRecentChatsAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteRecentChatsAdminPayload> DeleteRecentChatsAsync(
            [Service] IRecentChatsAdminMutationService mutationService,
            [Service] IRecentChatsWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteRecentChatsAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendRecentChatsEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendRecentChatsEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultRecentChatsDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(RecentChatsAdminSubscription.OnRecentChatsAdminCreated),
                        RecentChatsAdminCreatedEvent.From<RecentChatsAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(RecentChatsAdminSubscription.OnRecentChatsAdminUpdated),
                        RecentChatsAdminUpdatedEvent.From<RecentChatsAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(RecentChatsAdminSubscription.OnRecentChatsAdminDeleted),
                        RecentChatsAdminDeletedEvent.From<RecentChatsAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(RecentChatsAdminSubscription.OnRecentChatsAdminChanged),
                RecentChatsAdminChangedEvent.From<RecentChatsAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }

}

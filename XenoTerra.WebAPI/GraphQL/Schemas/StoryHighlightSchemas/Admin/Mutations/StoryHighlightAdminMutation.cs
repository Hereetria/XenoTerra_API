using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightServices;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.StoryHighlightMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class StoryHighlightAdminMutation
    {
        public async Task<CreateStoryHighlightAdminPayload> CreateStoryHighlightAsync(
            [Service] IStoryHighlightAdminMutationService mutationService,
            [Service] IStoryHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateStoryHighlightAdminInput> inputAdminValidator,
            CreateStoryHighlightAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateStoryHighlightAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateStoryHighlightAdminInput, CreateStoryHighlightDto>(input);
            var payload = await mutationService.CreateAsync<CreateStoryHighlightAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendStoryHighlightEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateStoryHighlightAdminPayload> UpdateStoryHighlightAsync(
            [Service] IStoryHighlightAdminMutationService mutationService,
            [Service] IStoryHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateStoryHighlightAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateStoryHighlightAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateStoryHighlightAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateStoryHighlightAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateStoryHighlightAdminInput, UpdateStoryHighlightDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateStoryHighlightAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendStoryHighlightEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteStoryHighlightAdminPayload> DeleteStoryHighlightAsync(
            [Service] IStoryHighlightAdminMutationService mutationService,
            [Service] IStoryHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteStoryHighlightAdminPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendStoryHighlightEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendStoryHighlightEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultStoryHighlightDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(StoryHighlightAdminSubscription.OnStoryHighlightAdminCreated),
                        StoryHighlightAdminCreatedEvent.From<StoryHighlightAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(StoryHighlightAdminSubscription.OnStoryHighlightAdminUpdated),
                        StoryHighlightAdminUpdatedEvent.From<StoryHighlightAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(StoryHighlightAdminSubscription.OnStoryHighlightAdminDeleted),
                        StoryHighlightAdminDeletedEvent.From<StoryHighlightAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(StoryHighlightAdminSubscription.OnStoryHighlightAdminChanged),
                StoryHighlightAdminChangedEvent.From<StoryHighlightAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

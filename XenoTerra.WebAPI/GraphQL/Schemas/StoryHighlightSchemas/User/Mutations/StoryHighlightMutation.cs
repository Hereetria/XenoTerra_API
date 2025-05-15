using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightServices;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.StoryHighlightMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Mutations
{
    public class StoryHighlightMutation
    {
        public async Task<CreateStoryHighlightPayload> CreateStoryHighlightAsync(
            [Service] IStoryHighlightMutationService mutationService,
            [Service] IStoryHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateStoryHighlightInput> inputValidator,
            CreateStoryHighlightInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateStoryHighlightInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateStoryHighlightInput, CreateStoryHighlightDto>(input);
            var payload = await mutationService.CreateAsync<CreateStoryHighlightPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendStoryHighlightEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateStoryHighlightPayload> UpdateStoryHighlightAsync(
            [Service] IStoryHighlightMutationService mutationService,
            [Service] IStoryHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateStoryHighlightInput> inputValidator,
            IResolverContext context,
            UpdateStoryHighlightInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateStoryHighlightInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateStoryHighlightInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateStoryHighlightInput, UpdateStoryHighlightDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateStoryHighlightPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendStoryHighlightEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteStoryHighlightPayload> DeleteStoryHighlightAsync(
            [Service] IStoryHighlightMutationService mutationService,
            [Service] IStoryHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteStoryHighlightPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(StoryHighlightSubscription.OnStoryHighlightCreated),
                        StoryHighlightCreatedEvent.From<StoryHighlightCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(StoryHighlightSubscription.OnStoryHighlightUpdated),
                        StoryHighlightUpdatedEvent.From<StoryHighlightUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(StoryHighlightSubscription.OnStoryHighlightDeleted),
                        StoryHighlightDeletedEvent.From<StoryHighlightDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(StoryHighlightSubscription.OnStoryHighlightChanged),
                StoryHighlightChangedEvent.From<StoryHighlightChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

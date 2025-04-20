using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryHighlightServices;
using XenoTerra.DTOLayer.Dtos.StoryHighlightDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.StoryHighlightMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Mutations
{
    public class StoryHighlightMutation
    {
        public async Task<CreateStoryHighlightPayload> CreateStoryHighlightAsync(
            [Service] IStoryHighlightMutationService mutationService,
            [Service] IStoryHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateStoryHighlightInput? input)
        {
            if (!InputValidator.ValidateInputFields<StoryHighlight, CreateStoryHighlightInput, ResultStoryHighlightDto, CreateStoryHighlightPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateStoryHighlightInput, CreateStoryHighlightDto>(input);
            var payload = await mutationService.CreateAsync<CreateStoryHighlightPayload>(writeService, createDto);

            await SendStoryHighlightCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateStoryHighlightPayload> UpdateStoryHighlightAsync(
            [Service] IStoryHighlightMutationService mutationService,
            [Service] IStoryHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateStoryHighlightInput? input)
        {
            if (!InputValidator.ValidateInputFields<StoryHighlight, UpdateStoryHighlightInput, ResultStoryHighlightDto, UpdateStoryHighlightPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateStoryHighlightInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateStoryHighlightInput, UpdateStoryHighlightDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateStoryHighlightPayload>(writeService, updateDto, modifiedFields);

            await SendStoryHighlightUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteStoryHighlightPayload> DeleteStoryHighlightAsync(
            [Service] IStoryHighlightMutationService mutationService,
            [Service] IStoryHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<StoryHighlight, ResultStoryHighlightDto, DeleteStoryHighlightPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteStoryHighlightPayload>(writeService, parsedKey);

            await SendStoryHighlightDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendStoryHighlightCreatedEvents(ITopicEventSender sender, ResultStoryHighlightDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(StoryHighlightSubscription.OnStoryHighlightCreated),
                StoryHighlightCreatedEvent.From<StoryHighlightCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(StoryHighlightSubscription.OnStoryHighlightChanged),
                StoryHighlightChangedEvent.From<StoryHighlightChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendStoryHighlightUpdatedEvents(ITopicEventSender sender, ResultStoryHighlightDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(StoryHighlightSubscription.OnStoryHighlightUpdated),
                StoryHighlightUpdatedEvent.From<StoryHighlightUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(StoryHighlightSubscription.OnStoryHighlightChanged),
                StoryHighlightChangedEvent.From<StoryHighlightChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendStoryHighlightDeletedEvents(ITopicEventSender sender, ResultStoryHighlightDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(StoryHighlightSubscription.OnStoryHighlightDeleted),
                StoryHighlightDeletedEvent.From<StoryHighlightDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(StoryHighlightSubscription.OnStoryHighlightChanged),
                StoryHighlightChangedEvent.From<StoryHighlightChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}

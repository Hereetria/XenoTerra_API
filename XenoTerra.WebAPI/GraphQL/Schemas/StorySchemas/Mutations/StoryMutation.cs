using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryService;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.StoryMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Mutations
{
    public class StoryMutation
    {
        public async Task<CreateStoryPayload> CreateStoryAsync(
            [Service] IStoryMutationService mutationService,
            [Service] IStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateStoryInput? input)
        {
            if (!InputValidator.ValidateInputFields<Story, CreateStoryInput, ResultStoryDto, CreateStoryPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateStoryInput, CreateStoryDto>(input);
            var payload = await mutationService.CreateAsync<CreateStoryPayload>(writeService, createDto);

            await SendStoryCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateStoryPayload> UpdateStoryAsync(
            [Service] IStoryMutationService mutationService,
            [Service] IStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateStoryInput? input)
        {
            if (!InputValidator.ValidateInputFields<Story, UpdateStoryInput, ResultStoryDto, UpdateStoryPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateStoryInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateStoryInput, UpdateStoryDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateStoryPayload>(writeService, updateDto, modifiedFields);

            await SendStoryUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteStoryPayload> DeleteStoryAsync(
            [Service] IStoryMutationService mutationService,
            [Service] IStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<Story, ResultStoryDto, DeleteStoryPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteStoryPayload>(writeService, parsedKey);

            await SendStoryDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendStoryCreatedEvents(ITopicEventSender sender, ResultStoryDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(StorySubscription.OnStoryCreated),
                StoryCreatedEvent.From<StoryCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(StorySubscription.OnStoryChanged),
                StoryChangedEvent.From<StoryChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendStoryUpdatedEvents(ITopicEventSender sender, ResultStoryDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(StorySubscription.OnStoryUpdated),
                StoryUpdatedEvent.From<StoryUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(StorySubscription.OnStoryChanged),
                StoryChangedEvent.From<StoryChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendStoryDeletedEvents(ITopicEventSender sender, ResultStoryDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(StorySubscription.OnStoryDeleted),
                StoryDeletedEvent.From<StoryDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(StorySubscription.OnStoryChanged),
                StoryChangedEvent.From<StoryChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}

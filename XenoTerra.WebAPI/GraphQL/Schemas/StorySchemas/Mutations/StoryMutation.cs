using FluentValidation;
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
            [Service] IValidator<CreateStoryInput> inputValidator,
            CreateStoryInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateStoryInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateStoryInput, CreateStoryDto>(input);
            var payload = await mutationService.CreateAsync<CreateStoryPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateStoryPayload> UpdateStoryAsync(
            [Service] IStoryMutationService mutationService,
            [Service] IStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateStoryInput> inputValidator,
            IResolverContext context,
            UpdateStoryInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateStoryInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateStoryInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateStoryInput, UpdateStoryDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateStoryPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteStoryPayload> DeleteStoryAsync(
            [Service] IStoryMutationService mutationService,
            [Service] IStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var payload = await mutationService.DeleteAsync<DeleteStoryPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendStoryEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultStoryDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(StorySubscription.OnStoryCreated),
                        StoryCreatedEvent.From<StoryCreatedEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(StorySubscription.OnStoryUpdated),
                        StoryUpdatedEvent.From<StoryUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(StorySubscription.OnStoryDeleted),
                        StoryDeletedEvent.From<StoryDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(StorySubscription.OnStoryChanged),
                StoryChangedEvent.From<StoryChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

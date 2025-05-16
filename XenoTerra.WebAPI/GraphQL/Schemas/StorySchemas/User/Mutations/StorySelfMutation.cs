using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.StoryService;
using XenoTerra.DTOLayer.Dtos.StoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.StoryMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Mutations
{
    public class StorySelfMutation
    {
        public async Task<CreateStorySelfPayload> CreateStoryAsync(
            [Service] IStoryMutationService mutationService,
            [Service] IStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateStorySelfInput> inputSelfValidator,
            CreateStorySelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateStorySelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateStorySelfInput, CreateStoryDto>(input);
            var payload = await mutationService.CreateAsync<CreateStorySelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateStorySelfPayload> UpdateStoryAsync(
            [Service] IStoryMutationService mutationService,
            [Service] IStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateStorySelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateStorySelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateStorySelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateStorySelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateStorySelfInput, UpdateStoryDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateStorySelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendStoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteStorySelfPayload> DeleteStoryAsync(
            [Service] IStoryMutationService mutationService,
            [Service] IStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));
            var payload = await mutationService.DeleteAsync<DeleteStorySelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(StorySelfSubscription.OnStoryCreated),
                        StoryCreatedSelfEvent.From<StoryCreatedSelfEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(StorySelfSubscription.OnStoryUpdated),
                        StoryUpdatedSelfEvent.From<StoryUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(StorySelfSubscription.OnStoryDeleted),
                        StoryDeletedSelfEvent.From<StoryDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(StorySelfSubscription.OnStoryChanged),
                StoryChangedSelfEvent.From<StoryChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

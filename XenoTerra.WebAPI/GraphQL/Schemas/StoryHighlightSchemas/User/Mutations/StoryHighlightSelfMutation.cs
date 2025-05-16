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
    public class StoryHighlightSelfMutation
    {
        public async Task<CreateStoryHighlightSelfPayload> CreateStoryHighlightAsync(
            [Service] IStoryHighlightMutationService mutationService,
            [Service] IStoryHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateStoryHighlightSelfInput> inputSelfValidator,
            CreateStoryHighlightSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateStoryHighlightSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateStoryHighlightSelfInput, CreateStoryHighlightDto>(input);
            var payload = await mutationService.CreateAsync<CreateStoryHighlightSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendStoryHighlightEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateStoryHighlightSelfPayload> UpdateStoryHighlightAsync(
            [Service] IStoryHighlightMutationService mutationService,
            [Service] IStoryHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateStoryHighlightSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateStoryHighlightSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateStoryHighlightSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateStoryHighlightSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateStoryHighlightSelfInput, UpdateStoryHighlightDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateStoryHighlightSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendStoryHighlightEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteStoryHighlightSelfPayload> DeleteStoryHighlightAsync(
            [Service] IStoryHighlightMutationService mutationService,
            [Service] IStoryHighlightWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteStoryHighlightSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(StoryHighlightSelfSubscription.OnStoryHighlightCreated),
                        StoryHighlightCreatedSelfEvent.From<StoryHighlightCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(StoryHighlightSelfSubscription.OnStoryHighlightUpdated),
                        StoryHighlightUpdatedSelfEvent.From<StoryHighlightUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(StoryHighlightSelfSubscription.OnStoryHighlightDeleted),
                        StoryHighlightDeletedSelfEvent.From<StoryHighlightDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(StoryHighlightSelfSubscription.OnStoryHighlightChanged),
                StoryHighlightChangedSelfEvent.From<StoryHighlightChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

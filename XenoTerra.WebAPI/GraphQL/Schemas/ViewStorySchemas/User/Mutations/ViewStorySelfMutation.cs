using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.ViewStoryService;
using XenoTerra.DTOLayer.Dtos.ViewStoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.ViewStoryMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Mutations
{
    public class ViewStorySelfMutation
    {
        public async Task<CreateViewStorySelfPayload> CreateViewStoryAsync(
            [Service] IViewStoryMutationService mutationService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateViewStorySelfInput> inputSelfValidator,
            CreateViewStorySelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateViewStorySelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateViewStorySelfInput, CreateViewStoryDto>(input);
            var payload = await mutationService.CreateAsync<CreateViewStorySelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendViewStoryEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateViewStorySelfPayload> UpdateViewStoryAsync(
            [Service] IViewStoryMutationService mutationService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateViewStorySelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateViewStorySelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateViewStorySelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateViewStorySelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateViewStorySelfInput, UpdateViewStoryDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateViewStorySelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendViewStoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteViewStorySelfPayload> DeleteViewStoryAsync(
            [Service] IViewStoryMutationService mutationService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteViewStorySelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendViewStoryEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendViewStoryEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultViewStoryDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(ViewStorySelfSubscription.OnViewStoryCreated),
                        ViewStoryCreatedSelfEvent.From<ViewStoryCreatedSelfEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ViewStorySelfSubscription.OnViewStoryUpdated),
                        ViewStoryUpdatedSelfEvent.From<ViewStoryUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ViewStorySelfSubscription.OnViewStoryDeleted),
                        ViewStoryDeletedSelfEvent.From<ViewStoryDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ViewStorySelfSubscription.OnViewStoryChanged),
                ViewStoryChangedSelfEvent.From<ViewStoryChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

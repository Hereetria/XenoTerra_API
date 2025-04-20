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
    public class ViewStoryMutation
    {
        public async Task<CreateViewStoryPayload> CreateViewStoryAsync(
            [Service] IViewStoryMutationService mutationService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateViewStoryInput? input)
        {
            if (!InputValidator.ValidateInputFields<ViewStory, CreateViewStoryInput, ResultViewStoryDto, CreateViewStoryPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateViewStoryInput, CreateViewStoryDto>(input);
            var payload = await mutationService.CreateAsync<CreateViewStoryPayload>(writeService, createDto);

            await SendViewStoryCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateViewStoryPayload> UpdateViewStoryAsync(
            [Service] IViewStoryMutationService mutationService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateViewStoryInput? input)
        {
            if (!InputValidator.ValidateInputFields<ViewStory, UpdateViewStoryInput, ResultViewStoryDto, UpdateViewStoryPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateViewStoryInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateViewStoryInput, UpdateViewStoryDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateViewStoryPayload>(writeService, updateDto, modifiedFields);

            await SendViewStoryUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteViewStoryPayload> DeleteViewStoryAsync(
            [Service] IViewStoryMutationService mutationService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<ViewStory, ResultViewStoryDto, DeleteViewStoryPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteViewStoryPayload>(writeService, parsedKey);

            await SendViewStoryDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendViewStoryCreatedEvents(ITopicEventSender sender, ResultViewStoryDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(ViewStorySubscription.OnViewStoryCreated),
                ViewStoryCreatedEvent.From<ViewStoryCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(ViewStorySubscription.OnViewStoryChanged),
                ViewStoryChangedEvent.From<ViewStoryChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendViewStoryUpdatedEvents(ITopicEventSender sender, ResultViewStoryDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(ViewStorySubscription.OnViewStoryUpdated),
                ViewStoryUpdatedEvent.From<ViewStoryUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(ViewStorySubscription.OnViewStoryChanged),
                ViewStoryChangedEvent.From<ViewStoryChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendViewStoryDeletedEvents(ITopicEventSender sender, ResultViewStoryDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(ViewStorySubscription.OnViewStoryDeleted),
                ViewStoryDeletedEvent.From<ViewStoryDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(ViewStorySubscription.OnViewStoryChanged),
                ViewStoryChangedEvent.From<ViewStoryChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}

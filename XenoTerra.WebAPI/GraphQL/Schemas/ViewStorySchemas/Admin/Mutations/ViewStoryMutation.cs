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
    public class ViewStoryMutation
    {
        public async Task<CreateViewStoryPayload> CreateViewStoryAsync(
            [Service] IViewStoryMutationService mutationService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateViewStoryInput> inputValidator,
            CreateViewStoryInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateViewStoryInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateViewStoryInput, CreateViewStoryDto>(input);
            var payload = await mutationService.CreateAsync<CreateViewStoryPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendViewStoryEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateViewStoryPayload> UpdateViewStoryAsync(
            [Service] IViewStoryMutationService mutationService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateViewStoryInput> inputValidator,
            IResolverContext context,
            UpdateViewStoryInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateViewStoryInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateViewStoryInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateViewStoryInput, UpdateViewStoryDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateViewStoryPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendViewStoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteViewStoryPayload> DeleteViewStoryAsync(
            [Service] IViewStoryMutationService mutationService,
            [Service] IViewStoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteViewStoryPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(ViewStorySubscription.OnViewStoryCreated),
                        ViewStoryCreatedEvent.From<ViewStoryCreatedEvent>(result, userId, now));
                    break;
                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(ViewStorySubscription.OnViewStoryUpdated),
                        ViewStoryUpdatedEvent.From<ViewStoryUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;
                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(ViewStorySubscription.OnViewStoryDeleted),
                        ViewStoryDeletedEvent.From<ViewStoryDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(ViewStorySubscription.OnViewStoryChanged),
                ViewStoryChangedEvent.From<ViewStoryChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

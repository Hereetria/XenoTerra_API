using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.SavedPostService;
using XenoTerra.DTOLayer.Dtos.SavedPostDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.SavedPostMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.SavedPostMutations
{
    public class SavedPostMutation
    {
        public async Task<CreateSavedPostPayload> CreateSavedPostAsync(
            [Service] ISavedPostMutationService mutationService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateSavedPostInput? input)
        {
            if (!InputValidator.ValidateInputFields<SavedPost, CreateSavedPostInput, ResultSavedPostDto, CreateSavedPostPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateSavedPostInput, CreateSavedPostDto>(input);
            var payload = await mutationService.CreateAsync<CreateSavedPostPayload>(writeService, createDto);

            await SendSavedPostCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateSavedPostPayload> UpdateSavedPostAsync(
            [Service] ISavedPostMutationService mutationService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateSavedPostInput? input)
        {
            if (!InputValidator.ValidateInputFields<SavedPost, UpdateSavedPostInput, ResultSavedPostDto, UpdateSavedPostPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSavedPostInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSavedPostInput, UpdateSavedPostDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateSavedPostPayload>(writeService, updateDto, modifiedFields);

            await SendSavedPostUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteSavedPostPayload> DeleteSavedPostAsync(
            [Service] ISavedPostMutationService mutationService,
            [Service] ISavedPostWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<SavedPost, ResultSavedPostDto, DeleteSavedPostPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteSavedPostPayload>(writeService, parsedKey);

            await SendSavedPostDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendSavedPostCreatedEvents(ITopicEventSender sender, ResultSavedPostDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(SavedPostSubscription.OnSavedPostCreated),
                SavedPostCreatedEvent.From<SavedPostCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(SavedPostSubscription.OnSavedPostChanged),
                SavedPostChangedEvent.From<SavedPostChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendSavedPostUpdatedEvents(ITopicEventSender sender, ResultSavedPostDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(SavedPostSubscription.OnSavedPostUpdated),
                SavedPostUpdatedEvent.From<SavedPostUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(SavedPostSubscription.OnSavedPostChanged),
                SavedPostChangedEvent.From<SavedPostChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendSavedPostDeletedEvents(ITopicEventSender sender, ResultSavedPostDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(SavedPostSubscription.OnSavedPostDeleted),
                SavedPostDeletedEvent.From<SavedPostDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(SavedPostSubscription.OnSavedPostChanged),
                SavedPostChangedEvent.From<SavedPostChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}

using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryService;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.SearchHistoryMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.SearchHistoryMutations
{
    public class SearchHistoryMutation
    {
        public async Task<CreateSearchHistoryPayload> CreateSearchHistoryAsync(
            [Service] ISearchHistoryMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateSearchHistoryInput? input)
        {
            if (!InputValidator.ValidateInputFields<SearchHistory, CreateSearchHistoryInput, ResultSearchHistoryDto, CreateSearchHistoryPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateSearchHistoryInput, CreateSearchHistoryDto>(input);
            var payload = await mutationService.CreateAsync<CreateSearchHistoryPayload>(writeService, createDto);

            await SendSearchHistoryCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateSearchHistoryPayload> UpdateSearchHistoryAsync(
            [Service] ISearchHistoryMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateSearchHistoryInput? input)
        {
            if (!InputValidator.ValidateInputFields<SearchHistory, UpdateSearchHistoryInput, ResultSearchHistoryDto, UpdateSearchHistoryPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSearchHistoryInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSearchHistoryInput, UpdateSearchHistoryDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateSearchHistoryPayload>(writeService, updateDto, modifiedFields);

            await SendSearchHistoryUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteSearchHistoryPayload> DeleteSearchHistoryAsync(
            [Service] ISearchHistoryMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<SearchHistory, ResultSearchHistoryDto, DeleteSearchHistoryPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteSearchHistoryPayload>(writeService, parsedKey);

            await SendSearchHistoryDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendSearchHistoryCreatedEvents(ITopicEventSender sender, ResultSearchHistoryDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(SearchHistorySubscription.OnSearchHistoryCreated),
                SearchHistoryCreatedEvent.From<SearchHistoryCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(SearchHistorySubscription.OnSearchHistoryChanged),
                SearchHistoryChangedEvent.From<SearchHistoryChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendSearchHistoryUpdatedEvents(ITopicEventSender sender, ResultSearchHistoryDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(SearchHistorySubscription.OnSearchHistoryUpdated),
                SearchHistoryUpdatedEvent.From<SearchHistoryUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(SearchHistorySubscription.OnSearchHistoryChanged),
                SearchHistoryChangedEvent.From<SearchHistoryChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendSearchHistoryDeletedEvents(ITopicEventSender sender, ResultSearchHistoryDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(SearchHistorySubscription.OnSearchHistoryDeleted),
                SearchHistoryDeletedEvent.From<SearchHistoryDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(SearchHistorySubscription.OnSearchHistoryChanged),
                SearchHistoryChangedEvent.From<SearchHistoryChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}

using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryService;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.SearchHistoryMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Mutations
{
    public class SearchHistoryMutation
    {
        public async Task<CreateSearchHistoryPayload> CreateSearchHistoryAsync(
            [Service] ISearchHistoryMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateSearchHistoryInput> inputValidator,
            CreateSearchHistoryInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateSearchHistoryInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateSearchHistoryInput, CreateSearchHistoryDto>(input);
            var payload = await mutationService.CreateAsync<CreateSearchHistoryPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendSearchHistoryEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateSearchHistoryPayload> UpdateSearchHistoryAsync(
            [Service] ISearchHistoryMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateSearchHistoryInput> inputValidator,
            IResolverContext context,
            UpdateSearchHistoryInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateSearchHistoryInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSearchHistoryInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSearchHistoryInput, UpdateSearchHistoryDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateSearchHistoryPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendSearchHistoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteSearchHistoryPayload> DeleteSearchHistoryAsync(
            [Service] ISearchHistoryMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteSearchHistoryPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendSearchHistoryEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendSearchHistoryEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultSearchHistoryDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(SearchHistorySubscription.OnSearchHistoryCreated),
                        SearchHistoryCreatedEvent.From<SearchHistoryCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(SearchHistorySubscription.OnSearchHistoryUpdated),
                        SearchHistoryUpdatedEvent.From<SearchHistoryUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(SearchHistorySubscription.OnSearchHistoryDeleted),
                        SearchHistoryDeletedEvent.From<SearchHistoryDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(SearchHistorySubscription.OnSearchHistoryChanged),
                SearchHistoryChangedEvent.From<SearchHistoryChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

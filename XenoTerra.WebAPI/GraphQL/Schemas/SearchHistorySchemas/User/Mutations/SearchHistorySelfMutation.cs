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
    public class SearchHistorySelfMutation
    {
        public async Task<CreateSearchHistorySelfPayload> CreateSearchHistoryAsync(
            [Service] ISearchHistoryMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateSearchHistorySelfInput> inputSelfValidator,
            CreateSearchHistorySelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateSearchHistorySelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateSearchHistorySelfInput, CreateSearchHistoryDto>(input);
            var payload = await mutationService.CreateAsync<CreateSearchHistorySelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendSearchHistoryEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateSearchHistorySelfPayload> UpdateSearchHistoryAsync(
            [Service] ISearchHistoryMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateSearchHistorySelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateSearchHistorySelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateSearchHistorySelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSearchHistorySelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSearchHistorySelfInput, UpdateSearchHistoryDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateSearchHistorySelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendSearchHistoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteSearchHistorySelfPayload> DeleteSearchHistoryAsync(
            [Service] ISearchHistoryMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteSearchHistorySelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(SearchHistorySelfSubscription.OnSearchHistoryCreated),
                        SearchHistoryCreatedSelfEvent.From<SearchHistoryCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(SearchHistorySelfSubscription.OnSearchHistoryUpdated),
                        SearchHistoryUpdatedSelfEvent.From<SearchHistoryUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(SearchHistorySelfSubscription.OnSearchHistoryDeleted),
                        SearchHistoryDeletedSelfEvent.From<SearchHistoryDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(SearchHistorySelfSubscription.OnSearchHistoryChanged),
                SearchHistoryChangedSelfEvent.From<SearchHistoryChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

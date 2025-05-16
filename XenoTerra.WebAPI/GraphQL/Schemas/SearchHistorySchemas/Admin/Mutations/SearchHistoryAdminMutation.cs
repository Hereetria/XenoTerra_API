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
    public class SearchHistoryAdminMutation
    {
        public async Task<CreateSearchHistoryAdminPayload> CreateSearchHistoryAsync(
            [Service] ISearchHistoryMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<CreateSearchHistoryAdminInput> inputAdminValidator,
            CreateSearchHistoryAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateSearchHistoryAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateSearchHistoryAdminInput, CreateSearchHistoryDto>(input);
            var payload = await mutationService.CreateAsync<CreateSearchHistoryAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendSearchHistoryEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateSearchHistoryAdminPayload> UpdateSearchHistoryAsync(
            [Service] ISearchHistoryMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IAdminValidator<UpdateSearchHistoryAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateSearchHistoryAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateSearchHistoryAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSearchHistoryAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSearchHistoryAdminInput, UpdateSearchHistoryDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateSearchHistoryAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendSearchHistoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteSearchHistoryAdminPayload> DeleteSearchHistoryAsync(
            [Service] ISearchHistoryMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteSearchHistoryAdminPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(SearchHistoryAdminSubscription.OnSearchHistoryCreated),
                        SearchHistoryCreatedAdminEvent.From<SearchHistoryCreatedAdminEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(SearchHistoryAdminSubscription.OnSearchHistoryUpdated),
                        SearchHistoryUpdatedAdminEvent.From<SearchHistoryUpdatedAdminEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(SearchHistoryAdminSubscription.OnSearchHistoryDeleted),
                        SearchHistoryDeletedAdminEvent.From<SearchHistoryDeletedAdminEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(SearchHistoryAdminSubscription.OnSearchHistoryChanged),
                SearchHistoryChangedAdminEvent.From<SearchHistoryChangedAdminEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

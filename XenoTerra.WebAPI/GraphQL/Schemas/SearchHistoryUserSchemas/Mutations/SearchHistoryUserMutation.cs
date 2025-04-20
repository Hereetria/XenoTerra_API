using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserServices;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.SearchHistoryUserMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Mutations
{
    public class SearchHistoryUserMutation
    {
        public async Task<CreateSearchHistoryUserPayload> CreateSearchHistoryUserAsync(
            [Service] ISearchHistoryUserMutationService mutationService,
            [Service] ISearchHistoryUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            CreateSearchHistoryUserInput? input)
        {
            if (!InputValidator.ValidateInputFields<SearchHistoryUser, CreateSearchHistoryUserInput, ResultSearchHistoryUserDto, CreateSearchHistoryUserPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var createDto = DtoMapperHelper.MapInputToDto<CreateSearchHistoryUserInput, CreateSearchHistoryUserDto>(input);
            var payload = await mutationService.CreateAsync<CreateSearchHistoryUserPayload>(writeService, createDto);

            await SendSearchHistoryUserCreatedEvents(eventSender, payload.Result);

            return payload;
        }

        public async Task<UpdateSearchHistoryUserPayload> UpdateSearchHistoryUserAsync(
            [Service] ISearchHistoryUserMutationService mutationService,
            [Service] ISearchHistoryUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            UpdateSearchHistoryUserInput? input)
        {
            if (!InputValidator.ValidateInputFields<SearchHistoryUser, UpdateSearchHistoryUserInput, ResultSearchHistoryUserDto, UpdateSearchHistoryUserPayload>(
                    input, context, out var validationPayload))
                return validationPayload;

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSearchHistoryUserInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSearchHistoryUserInput, UpdateSearchHistoryUserDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateSearchHistoryUserPayload>(writeService, updateDto, modifiedFields);

            await SendSearchHistoryUserUpdatedEvents(eventSender, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteSearchHistoryUserPayload> DeleteSearchHistoryUserAsync(
            [Service] ISearchHistoryUserMutationService mutationService,
            [Service] ISearchHistoryUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            IResolverContext context,
            string? key)
        {
            if (!InputValidator.ValidateGuidInput<SearchHistoryUser, ResultSearchHistoryUserDto, DeleteSearchHistoryUserPayload>(key, context, out var validationPayload))
                return validationPayload;

            _ = Guid.TryParse(key, out var parsedKey);
            var payload = await mutationService.DeleteAsync<DeleteSearchHistoryUserPayload>(writeService, parsedKey);

            await SendSearchHistoryUserDeletedEvents(eventSender, payload.Result);

            return payload;
        }

        private async Task SendSearchHistoryUserCreatedEvents(ITopicEventSender sender, ResultSearchHistoryUserDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(SearchHistoryUserSubscription.OnSearchHistoryUserCreated),
                SearchHistoryUserCreatedEvent.From<SearchHistoryUserCreatedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(SearchHistoryUserSubscription.OnSearchHistoryUserChanged),
                SearchHistoryUserChangedEvent.From<SearchHistoryUserChangedEvent>(ChangedEventType.Created, result, Guid.Empty, DateTime.UtcNow));
        }

        private async Task SendSearchHistoryUserUpdatedEvents(ITopicEventSender sender, ResultSearchHistoryUserDto? result, IEnumerable<string> modifiedFields)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(SearchHistoryUserSubscription.OnSearchHistoryUserUpdated),
                SearchHistoryUserUpdatedEvent.From<SearchHistoryUserUpdatedEvent>(result, Guid.Empty, DateTime.UtcNow, modifiedFields));

            await sender.SendAsync(nameof(SearchHistoryUserSubscription.OnSearchHistoryUserChanged),
                SearchHistoryUserChangedEvent.From<SearchHistoryUserChangedEvent>(ChangedEventType.Updated, result, Guid.Empty, DateTime.UtcNow, modifiedFields));
        }

        private async Task SendSearchHistoryUserDeletedEvents(ITopicEventSender sender, ResultSearchHistoryUserDto? result)
        {
            if (result is null)
                return;

            await sender.SendAsync(nameof(SearchHistoryUserSubscription.OnSearchHistoryUserDeleted),
                SearchHistoryUserDeletedEvent.From<SearchHistoryUserDeletedEvent>(result, Guid.Empty, DateTime.UtcNow));

            await sender.SendAsync(nameof(SearchHistoryUserSubscription.OnSearchHistoryUserChanged),
                SearchHistoryUserChangedEvent.From<SearchHistoryUserChangedEvent>(ChangedEventType.Deleted, result, Guid.Empty, DateTime.UtcNow));
        }
    }
}

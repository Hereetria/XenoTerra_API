using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserServices;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.SharedTypes.Events;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.SearchHistoryUserMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations
{
    public class SearchHistoryUserMutation
    {
        public async Task<CreateSearchHistoryUserPayload> CreateSearchHistoryUserAsync(
            [Service] ISearchHistoryUserMutationService mutationService,
            [Service] ISearchHistoryUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateSearchHistoryUserInput> inputValidator,
            CreateSearchHistoryUserInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateSearchHistoryUserInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateSearchHistoryUserInput, CreateSearchHistoryUserDto>(input);
            var payload = await mutationService.CreateAsync<CreateSearchHistoryUserPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendSearchHistoryUserEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateSearchHistoryUserPayload> UpdateSearchHistoryUserAsync(
            [Service] ISearchHistoryUserMutationService mutationService,
            [Service] ISearchHistoryUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateSearchHistoryUserInput> inputValidator,
            IResolverContext context,
            UpdateSearchHistoryUserInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateSearchHistoryUserInput));
            await ValidationGuard.ValidateOrThrowAsync(inputValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSearchHistoryUserInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSearchHistoryUserInput, UpdateSearchHistoryUserDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateSearchHistoryUserPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendSearchHistoryUserEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteSearchHistoryUserPayload> DeleteSearchHistoryUserAsync(
            [Service] ISearchHistoryUserMutationService mutationService,
            [Service] ISearchHistoryUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteSearchHistoryUserPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendSearchHistoryUserEventAsync(eventSender, ChangedEventType.Deleted, payload.Result);

            return payload;
        }

        private async Task SendSearchHistoryUserEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultSearchHistoryUserDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(SearchHistoryUserSubscription.OnSearchHistoryUserCreated),
                        SearchHistoryUserCreatedEvent.From<SearchHistoryUserCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(SearchHistoryUserSubscription.OnSearchHistoryUserUpdated),
                        SearchHistoryUserUpdatedEvent.From<SearchHistoryUserUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(SearchHistoryUserSubscription.OnSearchHistoryUserDeleted),
                        SearchHistoryUserDeletedEvent.From<SearchHistoryUserDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(SearchHistoryUserSubscription.OnSearchHistoryUserChanged),
                SearchHistoryUserChangedEvent.From<SearchHistoryUserChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

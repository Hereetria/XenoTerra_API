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
    public class SearchHistoryUserSelfMutation
    {
        public async Task<CreateSearchHistoryUserSelfPayload> CreateSearchHistoryUserAsync(
            [Service] ISearchHistoryUserMutationService mutationService,
            [Service] ISearchHistoryUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<CreateSearchHistoryUserSelfInput> inputSelfValidator,
            CreateSearchHistoryUserSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateSearchHistoryUserSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateSearchHistoryUserSelfInput, CreateSearchHistoryUserDto>(input);
            var payload = await mutationService.CreateAsync<CreateSearchHistoryUserSelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendSearchHistoryUserEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateSearchHistoryUserSelfPayload> UpdateSearchHistoryUserAsync(
            [Service] ISearchHistoryUserMutationService mutationService,
            [Service] ISearchHistoryUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] ISelfValidator<UpdateSearchHistoryUserSelfInput> inputSelfValidator,
            IResolverContext context,
            UpdateSearchHistoryUserSelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateSearchHistoryUserSelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSearchHistoryUserSelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSearchHistoryUserSelfInput, UpdateSearchHistoryUserDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateSearchHistoryUserSelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendSearchHistoryUserEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteSearchHistoryUserSelfPayload> DeleteSearchHistoryUserAsync(
            [Service] ISearchHistoryUserMutationService mutationService,
            [Service] ISearchHistoryUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteSearchHistoryUserSelfPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(SearchHistoryUserSelfSubscription.OnSearchHistoryUserCreated),
                        SearchHistoryUserCreatedSelfEvent.From<SearchHistoryUserCreatedSelfEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(SearchHistoryUserSelfSubscription.OnSearchHistoryUserUpdated),
                        SearchHistoryUserUpdatedSelfEvent.From<SearchHistoryUserUpdatedSelfEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(SearchHistoryUserSelfSubscription.OnSearchHistoryUserDeleted),
                        SearchHistoryUserDeletedSelfEvent.From<SearchHistoryUserDeletedSelfEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(SearchHistoryUserSelfSubscription.OnSearchHistoryUserChanged),
                SearchHistoryUserChangedSelfEvent.From<SearchHistoryUserChangedSelfEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

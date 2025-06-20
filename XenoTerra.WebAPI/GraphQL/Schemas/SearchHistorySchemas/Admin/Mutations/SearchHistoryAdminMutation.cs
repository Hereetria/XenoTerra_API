using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.SearchHistoryMutationServices;
using XenoTerra.DTOLayer.Dtos.SearchHistoryAdminDtos.Admin;
using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryServices.Write.Admin;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class SearchHistoryAdminMutation
    {
        public async Task<CreateSearchHistoryAdminPayload> CreateSearchHistoryAsync(
            [Service] ISearchHistoryAdminMutationService mutationService,
            [Service] ISearchHistoryAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateSearchHistoryAdminInput> inputAdminValidator,
            CreateSearchHistoryAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateSearchHistoryAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateSearchHistoryAdminInput, CreateSearchHistoryAdminDto>(input);
            var payload = await mutationService.CreateAsync<CreateSearchHistoryAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendSearchHistoryEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateSearchHistoryAdminPayload> UpdateSearchHistoryAsync(
            [Service] ISearchHistoryAdminMutationService mutationService,
            [Service] ISearchHistoryAdminWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateSearchHistoryAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateSearchHistoryAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateSearchHistoryAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSearchHistoryAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSearchHistoryAdminInput, UpdateSearchHistoryAdminDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateSearchHistoryAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendSearchHistoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteSearchHistoryAdminPayload> DeleteSearchHistoryAsync(
            [Service] ISearchHistoryAdminMutationService mutationService,
            [Service] ISearchHistoryAdminWriteService writeService,
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
            ResultSearchHistoryAdminDto result,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;
            var userId = Guid.Empty;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(SearchHistoryAdminSubscription.OnSearchHistoryAdminCreated),
                        SearchHistoryAdminCreatedEvent.From<SearchHistoryAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(SearchHistoryAdminSubscription.OnSearchHistoryAdminUpdated),
                        SearchHistoryAdminUpdatedEvent.From<SearchHistoryAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(SearchHistoryAdminSubscription.OnSearchHistoryAdminDeleted),
                        SearchHistoryAdminDeletedEvent.From<SearchHistoryAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(SearchHistoryAdminSubscription.OnSearchHistoryAdminChanged),
                SearchHistoryAdminChangedEvent.From<SearchHistoryAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

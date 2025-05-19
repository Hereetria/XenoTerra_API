using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryUserServices;
using XenoTerra.DTOLayer.Dtos.SearchHistoryUserDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Admin.SearchHistoryUserMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Mutations
{
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class SearchHistoryUserAdminMutation
    {
        public async Task<CreateSearchHistoryUserAdminPayload> CreateSearchHistoryUserAsync(
            [Service] ISearchHistoryUserAdminMutationService mutationService,
            [Service] ISearchHistoryUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateSearchHistoryUserAdminInput> inputAdminValidator,
            CreateSearchHistoryUserAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateSearchHistoryUserAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateSearchHistoryUserAdminInput, CreateSearchHistoryUserDto>(input);
            var payload = await mutationService.CreateAsync<CreateSearchHistoryUserAdminPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendSearchHistoryUserEventAsync(eventSender, ChangedEventType.Created, payload.Result);

            return payload;
        }

        public async Task<UpdateSearchHistoryUserAdminPayload> UpdateSearchHistoryUserAsync(
            [Service] ISearchHistoryUserAdminMutationService mutationService,
            [Service] ISearchHistoryUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateSearchHistoryUserAdminInput> inputAdminValidator,
            IResolverContext context,
            UpdateSearchHistoryUserAdminInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateSearchHistoryUserAdminInput));
            await ValidationGuard.ValidateOrThrowAsync(inputAdminValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSearchHistoryUserAdminInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSearchHistoryUserAdminInput, UpdateSearchHistoryUserDto>(input, modifiedFields);

            var payload = await mutationService.UpdateAsync<UpdateSearchHistoryUserAdminPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendSearchHistoryUserEventAsync(eventSender, ChangedEventType.Updated, payload.Result, modifiedFields);

            return payload;
        }

        public async Task<DeleteSearchHistoryUserAdminPayload> DeleteSearchHistoryUserAsync(
            [Service] ISearchHistoryUserAdminMutationService mutationService,
            [Service] ISearchHistoryUserWriteService writeService,
            [Service] ITopicEventSender eventSender,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var payload = await mutationService.DeleteAsync<DeleteSearchHistoryUserAdminPayload>(writeService, parsedKey);

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
                    await sender.SendAsync(nameof(SearchHistoryUserAdminSubscription.OnSearchHistoryUserAdminCreated),
                        SearchHistoryUserAdminCreatedEvent.From<SearchHistoryUserAdminCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(SearchHistoryUserAdminSubscription.OnSearchHistoryUserAdminUpdated),
                        SearchHistoryUserAdminUpdatedEvent.From<SearchHistoryUserAdminUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(SearchHistoryUserAdminSubscription.OnSearchHistoryUserAdminDeleted),
                        SearchHistoryUserAdminDeletedEvent.From<SearchHistoryUserAdminDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(SearchHistoryUserAdminSubscription.OnSearchHistoryUserAdminChanged),
                SearchHistoryUserAdminChangedEvent.From<SearchHistoryUserAdminChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using FluentValidation;
using HotChocolate.Resolvers;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Http;
using XenoTerra.BussinessLogicLayer.Services.Entity.SearchHistoryServices;
using XenoTerra.DTOLayer.Dtos.SearchHistoryDtos;
using XenoTerra.EntityLayer.Entities;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Mutations.Inputs;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Mutations.Payloads;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Types.EventTypes;
using XenoTerra.WebAPI.Helpers;
using XenoTerra.WebAPI.Services.Mutations.Entity.Self.SearchHistoryMutationServices;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Mutations
{
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class SearchHistorySelfMutation
    {
        public async Task<CreateSearchHistorySelfPayload> CreateMySearchHistoryAsync(
            [Service] ISearchHistorySelfMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<CreateSearchHistorySelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            CreateSearchHistorySelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(CreateSearchHistorySelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var createDto = DtoMapperHelper.MapInputToDto<CreateSearchHistorySelfInput, CreateSearchHistoryDto>(input);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            createDto.UserId = userId;

            var payload = await mutationService.CreateAsync<CreateSearchHistorySelfPayload>(writeService, createDto);

            if (payload.IsSuccess())
                await SendSearchHistoryEventAsync(eventSender, ChangedEventType.Created, payload.Result, userId);

            return payload;
        }

        public async Task<UpdateSearchHistorySelfPayload> UpdateMySearchHistoryAsync(
            [Service] ISearchHistorySelfMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IValidator<UpdateSearchHistorySelfInput> inputSelfValidator,
            [Service] IHttpContextAccessor httpContextAccessor,
            IResolverContext context,
            UpdateSearchHistorySelfInput? input)
        {
            InputGuard.EnsureNotNull(input, nameof(UpdateSearchHistorySelfInput));
            await ValidationGuard.ValidateOrThrowAsync(inputSelfValidator, input);

            var modifiedFields = GraphQLFieldProvider.GetSelectedParameterFields<UpdateSearchHistorySelfInput>(context, nameof(input));
            var updateDto = DtoMapperHelper.MapInputToDto<UpdateSearchHistorySelfInput, UpdateSearchHistoryDto>(input, modifiedFields);

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);
            updateDto.UserId = userId;

            var payload = await mutationService.UpdateAsync<UpdateSearchHistorySelfPayload>(writeService, updateDto, modifiedFields);

            if (payload.IsSuccess())
                await SendSearchHistoryEventAsync(eventSender, ChangedEventType.Updated, payload.Result, userId, modifiedFields);

            return payload;
        }

        public async Task<DeleteSearchHistorySelfPayload> DeleteMySearchHistoryAsync(
            [Service] ISearchHistorySelfMutationService mutationService,
            [Service] ISearchHistoryWriteService writeService,
            [Service] ITopicEventSender eventSender,
            [Service] IHttpContextAccessor httpContextAccessor,
            string? key)
        {
            var parsedKey = GuidParser.ParseGuidOrThrow(key, nameof(key));

            var userId = HttpContextUserHelper.GetMyUserId(httpContextAccessor.HttpContext);

            var payload = await mutationService.DeleteAsync<DeleteSearchHistorySelfPayload>(writeService, parsedKey);

            if (payload.IsSuccess())
                await SendSearchHistoryEventAsync(eventSender, ChangedEventType.Deleted, payload.Result, userId);

            return payload;
        }

        private async Task SendSearchHistoryEventAsync(
            ITopicEventSender sender,
            ChangedEventType eventType,
            ResultSearchHistoryDto result,
            Guid userId,
            IEnumerable<string>? modifiedFields = null)
        {
            var now = DateTime.UtcNow;

            switch (eventType)
            {
                case ChangedEventType.Created:
                    await sender.SendAsync(nameof(SearchHistorySelfSubscription.OnSearchHistorySelfCreated),
                        SearchHistorySelfCreatedEvent.From<SearchHistorySelfCreatedEvent>(result, userId, now));
                    break;

                case ChangedEventType.Updated:
                    await sender.SendAsync(nameof(SearchHistorySelfSubscription.OnSearchHistorySelfUpdated),
                        SearchHistorySelfUpdatedEvent.From<SearchHistorySelfUpdatedEvent>(result, userId, now, modifiedFields ?? []));
                    break;

                case ChangedEventType.Deleted:
                    await sender.SendAsync(nameof(SearchHistorySelfSubscription.OnSearchHistorySelfDeleted),
                        SearchHistorySelfDeletedEvent.From<SearchHistorySelfDeletedEvent>(result, userId, now));
                    break;
            }

            await sender.SendAsync(nameof(SearchHistorySelfSubscription.OnSearchHistorySelfChanged),
                SearchHistorySelfChangedEvent.From<SearchHistorySelfChangedEvent>(eventType, result, userId, now, modifiedFields));
        }
    }
}

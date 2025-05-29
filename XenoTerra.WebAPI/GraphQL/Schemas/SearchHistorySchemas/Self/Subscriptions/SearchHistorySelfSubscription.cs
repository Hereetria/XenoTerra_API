using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class SearchHistorySelfSubscription
    {
        [Subscribe]
        public SearchHistorySelfCreatedEvent OnSearchHistorySelfCreated(
            [EventMessage] SearchHistorySelfCreatedEvent evt) => evt;

        [Subscribe]
        public SearchHistorySelfUpdatedEvent OnSearchHistorySelfUpdated(
            [EventMessage] SearchHistorySelfUpdatedEvent evt) => evt;

        [Subscribe]
        public SearchHistorySelfDeletedEvent OnSearchHistorySelfDeleted(
            [EventMessage] SearchHistorySelfDeletedEvent evt) => evt;

        [Subscribe]
        public SearchHistorySelfChangedEvent OnSearchHistorySelfChanged(
            [EventMessage] SearchHistorySelfChangedEvent evt) => evt;
    }
}

using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class SearchHistoryAdminSubscription
    {
        [Subscribe]
        public SearchHistoryAdminCreatedEvent OnSearchHistoryAdminCreated(
            [EventMessage] SearchHistoryAdminCreatedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryAdminUpdatedEvent OnSearchHistoryAdminUpdated(
            [EventMessage] SearchHistoryAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryAdminDeletedEvent OnSearchHistoryAdminDeleted(
            [EventMessage] SearchHistoryAdminDeletedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryAdminChangedEvent OnSearchHistoryAdminChanged(
            [EventMessage] SearchHistoryAdminChangedEvent evt) => evt;
    }
}

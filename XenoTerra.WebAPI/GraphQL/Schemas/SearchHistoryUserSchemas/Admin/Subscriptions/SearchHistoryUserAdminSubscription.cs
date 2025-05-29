using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class SearchHistoryUserAdminSubscription
    {
        [Subscribe]
        public SearchHistoryUserAdminCreatedEvent OnSearchHistoryUserAdminCreated(
            [EventMessage] SearchHistoryUserAdminCreatedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUserAdminUpdatedEvent OnSearchHistoryUserAdminUpdated(
            [EventMessage] SearchHistoryUserAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUserAdminDeletedEvent OnSearchHistoryUserAdminDeleted(
            [EventMessage] SearchHistoryUserAdminDeletedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUserAdminChangedEvent OnSearchHistoryUserAdminChanged(
            [EventMessage] SearchHistoryUserAdminChangedEvent evt) => evt;
    }
}

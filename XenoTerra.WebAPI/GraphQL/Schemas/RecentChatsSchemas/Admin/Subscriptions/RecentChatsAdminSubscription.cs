using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class RecentChatsAdminSubscription
    {
        [Subscribe]
        public RecentChatsAdminCreatedEvent OnRecentChatsAdminCreated(
            [EventMessage] RecentChatsAdminCreatedEvent evt) => evt;

        [Subscribe]
        public RecentChatsAdminUpdatedEvent OnRecentChatsAdminUpdated(
            [EventMessage] RecentChatsAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public RecentChatsAdminDeletedEvent OnRecentChatsAdminDeleted(
            [EventMessage] RecentChatsAdminDeletedEvent evt) => evt;

        [Subscribe]
        public RecentChatsAdminChangedEvent OnRecentChatsAdminChanged(
            [EventMessage] RecentChatsAdminChangedEvent evt) => evt;
    }
}

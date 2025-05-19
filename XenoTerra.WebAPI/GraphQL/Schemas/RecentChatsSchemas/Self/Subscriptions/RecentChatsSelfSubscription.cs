using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class RecentChatsSelfSubscription
    {
        [Subscribe]
        public RecentChatsSelfCreatedEvent OnRecentChatsSelfCreated(
            [EventMessage] RecentChatsSelfCreatedEvent evt) => evt;

        [Subscribe]
        public RecentChatsSelfUpdatedEvent OnRecentChatsSelfUpdated(
            [EventMessage] RecentChatsSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public RecentChatsSelfDeletedEvent OnRecentChatsSelfDeleted(
            [EventMessage] RecentChatsSelfDeletedEvent evt) => evt;

        [Subscribe]
        public RecentChatsSelfChangedEvent OnRecentChatsSelfChanged(
            [EventMessage] RecentChatsSelfChangedEvent evt) => evt;
    }
}

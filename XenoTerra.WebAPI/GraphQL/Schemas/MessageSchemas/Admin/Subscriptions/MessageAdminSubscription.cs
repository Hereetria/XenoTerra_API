using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class MessageAdminSubscription
    {
        [Subscribe]
        public MessageAdminCreatedEvent OnMessageAdminCreated(
            [EventMessage] MessageAdminCreatedEvent evt) => evt;

        [Subscribe]
        public MessageAdminUpdatedEvent OnMessageAdminUpdated(
            [EventMessage] MessageAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public MessageAdminDeletedEvent OnMessageAdminDeleted(
            [EventMessage] MessageAdminDeletedEvent evt) => evt;

        [Subscribe]
        public MessageAdminChangedEvent OnMessageAdminChanged(
            [EventMessage] MessageAdminChangedEvent evt) => evt;
    }
}

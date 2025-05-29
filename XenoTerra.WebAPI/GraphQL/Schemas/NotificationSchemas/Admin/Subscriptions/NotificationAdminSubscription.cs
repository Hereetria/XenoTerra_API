using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class NotificationAdminSubscription
    {
        [Subscribe]
        public NotificationAdminCreatedEvent OnNotificationAdminCreated(
            [EventMessage] NotificationAdminCreatedEvent evt) => evt;

        [Subscribe]
        public NotificationAdminUpdatedEvent OnNotificationAdminUpdated(
            [EventMessage] NotificationAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public NotificationAdminDeletedEvent OnNotificationAdminDeleted(
            [EventMessage] NotificationAdminDeletedEvent evt) => evt;

        [Subscribe]
        public NotificationAdminChangedEvent OnNotificationAdminChanged(
            [EventMessage] NotificationAdminChangedEvent evt) => evt;
    }
}

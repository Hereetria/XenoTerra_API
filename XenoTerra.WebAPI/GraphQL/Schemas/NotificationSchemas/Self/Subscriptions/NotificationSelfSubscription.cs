using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class NotificationSelfSubscription
    {
        [Subscribe]
        public NotificationSelfCreatedEvent OnNotificationSelfCreated(
            [EventMessage] NotificationSelfCreatedEvent evt) => evt;

        [Subscribe]
        public NotificationSelfUpdatedEvent OnNotificationSelfUpdated(
            [EventMessage] NotificationSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public NotificationSelfDeletedEvent OnNotificationSelfDeleted(
            [EventMessage] NotificationSelfDeletedEvent evt) => evt;

        [Subscribe]
        public NotificationSelfChangedEvent OnNotificationSelfChanged(
            [EventMessage] NotificationSelfChangedEvent evt) => evt;
    }
}

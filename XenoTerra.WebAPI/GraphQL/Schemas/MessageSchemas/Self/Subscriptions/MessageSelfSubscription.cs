using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class MessageSelfSubscription
    {
        [Subscribe]
        public MessageSelfCreatedEvent OnMessageSelfCreated(
            [EventMessage] MessageSelfCreatedEvent evt) => evt;

        [Subscribe]
        public MessageSelfUpdatedEvent OnMessageSelfUpdated(
            [EventMessage] MessageSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public MessageSelfDeletedEvent OnMessageSelfDeleted(
            [EventMessage] MessageSelfDeletedEvent evt) => evt;

        [Subscribe]
        public MessageSelfChangedEvent OnMessageSelfChanged(
            [EventMessage] MessageSelfChangedEvent evt) => evt;
    }
}

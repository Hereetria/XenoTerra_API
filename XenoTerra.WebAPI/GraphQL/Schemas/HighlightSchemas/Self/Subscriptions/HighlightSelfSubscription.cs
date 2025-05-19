using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class HighlightSelfSubscription
    {
        [Subscribe]
        public HighlightSelfCreatedEvent OnHighlightSelfCreated(
            [EventMessage] HighlightSelfCreatedEvent evt) => evt;

        [Subscribe]
        public HighlightSelfUpdatedEvent OnHighlightSelfUpdated(
            [EventMessage] HighlightSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public HighlightSelfDeletedEvent OnHighlightSelfDeleted(
            [EventMessage] HighlightSelfDeletedEvent evt) => evt;

        [Subscribe]
        public HighlightSelfChangedEvent OnHighlightSelfChanged(
            [EventMessage] HighlightSelfChangedEvent evt) => evt;
    }
}

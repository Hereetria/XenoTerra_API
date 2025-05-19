using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class ViewStorySelfSubscription
    {
        [Subscribe]
        public ViewStorySelfCreatedEvent OnViewStorySelfCreated(
            [EventMessage] ViewStorySelfCreatedEvent evt) => evt;

        [Subscribe]
        public ViewStorySelfUpdatedEvent OnViewStorySelfUpdated(
            [EventMessage] ViewStorySelfUpdatedEvent evt) => evt;

        [Subscribe]
        public ViewStorySelfDeletedEvent OnViewStorySelfDeleted(
            [EventMessage] ViewStorySelfDeletedEvent evt) => evt;

        [Subscribe]
        public ViewStorySelfChangedEvent OnViewStorySelfChanged(
            [EventMessage] ViewStorySelfChangedEvent evt) => evt;
    }
}

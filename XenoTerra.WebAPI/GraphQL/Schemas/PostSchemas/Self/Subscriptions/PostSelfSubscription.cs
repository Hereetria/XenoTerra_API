using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class PostSelfSubscription
    {
        [Subscribe]
        public PostSelfCreatedEvent OnPostSelfCreated(
            [EventMessage] PostSelfCreatedEvent evt) => evt;

        [Subscribe]
        public PostSelfUpdatedEvent OnPostSelfUpdated(
            [EventMessage] PostSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public PostSelfDeletedEvent OnPostSelfDeleted(
            [EventMessage] PostSelfDeletedEvent evt) => evt;

        [Subscribe]
        public PostSelfChangedEvent OnPostSelfChanged(
            [EventMessage] PostSelfChangedEvent evt) => evt;
    }
}

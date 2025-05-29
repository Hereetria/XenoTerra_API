using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class FollowSelfSubscription
    {
        [Subscribe]
        public FollowSelfCreatedEvent OnFollowSelfCreated(
            [EventMessage] FollowSelfCreatedEvent evt) => evt;

        [Subscribe]
        public FollowSelfUpdatedEvent OnFollowSelfUpdated(
            [EventMessage] FollowSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public FollowSelfDeletedEvent OnFollowSelfDeleted(
            [EventMessage] FollowSelfDeletedEvent evt) => evt;

        [Subscribe]
        public FollowSelfChangedEvent OnFollowSelfChanged(
            [EventMessage] FollowSelfChangedEvent evt) => evt;
    }
}

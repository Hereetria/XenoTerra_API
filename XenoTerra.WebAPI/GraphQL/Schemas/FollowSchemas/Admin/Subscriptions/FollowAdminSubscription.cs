using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class FollowAdminSubscription
    {
        [Subscribe]
        public FollowAdminCreatedEvent OnFollowAdminCreated(
            [EventMessage] FollowAdminCreatedEvent evt) => evt;

        [Subscribe]
        public FollowAdminUpdatedEvent OnFollowAdminUpdated(
            [EventMessage] FollowAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public FollowAdminDeletedEvent OnFollowAdminDeleted(
            [EventMessage] FollowAdminDeletedEvent evt) => evt;

        [Subscribe]
        public FollowAdminChangedEvent OnFollowAdminChanged(
            [EventMessage] FollowAdminChangedEvent evt) => evt;
    }
}

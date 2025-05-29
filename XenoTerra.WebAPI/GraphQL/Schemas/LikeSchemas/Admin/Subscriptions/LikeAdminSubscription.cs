using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class LikeAdminSubscription
    {
        [Subscribe]
        public LikeAdminCreatedEvent OnLikeAdminCreated(
            [EventMessage] LikeAdminCreatedEvent evt) => evt;

        [Subscribe]
        public LikeAdminUpdatedEvent OnLikeAdminUpdated(
            [EventMessage] LikeAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public LikeAdminDeletedEvent OnLikeAdminDeleted(
            [EventMessage] LikeAdminDeletedEvent evt) => evt;

        [Subscribe]
        public LikeAdminChangedEvent OnLikeAdminChanged(
            [EventMessage] LikeAdminChangedEvent evt) => evt;
    }
}

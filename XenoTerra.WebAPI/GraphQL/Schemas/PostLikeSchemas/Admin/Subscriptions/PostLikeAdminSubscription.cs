using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class PostLikeAdminSubscription
    {
        [Subscribe]
        public PostLikeAdminCreatedEvent OnPostLikeAdminCreated(
            [EventMessage] PostLikeAdminCreatedEvent evt) => evt;

        [Subscribe]
        public PostLikeAdminUpdatedEvent OnPostLikeAdminUpdated(
            [EventMessage] PostLikeAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public PostLikeAdminDeletedEvent OnPostLikeAdminDeleted(
            [EventMessage] PostLikeAdminDeletedEvent evt) => evt;

        [Subscribe]
        public PostLikeAdminChangedEvent OnPostLikeAdminChanged(
            [EventMessage] PostLikeAdminChangedEvent evt) => evt;
    }
}

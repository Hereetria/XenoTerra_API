using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class CommentAdminSubscription
    {
        [Subscribe]
        public CommentAdminCreatedEvent OnCommentAdminCreated(
            [EventMessage] CommentAdminCreatedEvent evt) => evt;

        [Subscribe]
        public CommentAdminUpdatedEvent OnCommentAdminUpdated(
            [EventMessage] CommentAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public CommentAdminDeletedEvent OnCommentAdminDeleted(
            [EventMessage] CommentAdminDeletedEvent evt) => evt;

        [Subscribe]
        public CommentAdminChangedEvent OnCommentAdminChanged(
            [EventMessage] CommentAdminChangedEvent evt) => evt;
    }
}

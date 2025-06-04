using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class CommentLikeAdminSubscription
    {
        [Subscribe]
        public CommentLikeAdminCreatedEvent OnCommentLikeAdminCreated(
            [EventMessage] CommentLikeAdminCreatedEvent evt) => evt;

        [Subscribe]
        public CommentLikeAdminUpdatedEvent OnCommentLikeAdminUpdated(
            [EventMessage] CommentLikeAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public CommentLikeAdminDeletedEvent OnCommentLikeAdminDeleted(
            [EventMessage] CommentLikeAdminDeletedEvent evt) => evt;

        [Subscribe]
        public CommentLikeAdminChangedEvent OnCommentLikeAdminChanged(
            [EventMessage] CommentLikeAdminChangedEvent evt) => evt;
    }
}

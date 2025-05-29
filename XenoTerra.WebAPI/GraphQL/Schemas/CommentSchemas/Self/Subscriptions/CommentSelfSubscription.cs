using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class CommentSelfSubscription
    {
        [Subscribe]
        public CommentSelfCreatedEvent OnCommentSelfCreated(
            [EventMessage] CommentSelfCreatedEvent evt) => evt;

        [Subscribe]
        public CommentSelfUpdatedEvent OnCommentSelfUpdated(
            [EventMessage] CommentSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public CommentSelfDeletedEvent OnCommentSelfDeleted(
            [EventMessage] CommentSelfDeletedEvent evt) => evt;

        [Subscribe]
        public CommentSelfChangedEvent OnCommentSelfChanged(
            [EventMessage] CommentSelfChangedEvent evt) => evt;
    }
}

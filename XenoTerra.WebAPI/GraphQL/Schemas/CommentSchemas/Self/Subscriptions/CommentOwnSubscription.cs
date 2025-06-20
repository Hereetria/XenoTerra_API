using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class CommentOwnSubscription
    {
        [Subscribe]
        public CommentOwnCreatedEvent OnCommentOwnCreated(
            [EventMessage] CommentOwnCreatedEvent evt) => evt;

        [Subscribe]
        public CommentOwnUpdatedEvent OnCommentOwnUpdated(
            [EventMessage] CommentOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public CommentOwnDeletedEvent OnCommentOwnDeleted(
            [EventMessage] CommentOwnDeletedEvent evt) => evt;

        [Subscribe]
        public CommentOwnChangedEvent OnCommentOwnChanged(
            [EventMessage] CommentOwnChangedEvent evt) => evt;
    }
}

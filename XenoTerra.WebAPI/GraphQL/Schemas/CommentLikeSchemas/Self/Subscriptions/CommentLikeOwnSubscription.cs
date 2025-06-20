using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class CommentLikeOwnSubscription
    {
        [Subscribe]
        public CommentLikeOwnCreatedEvent OnLikeOwnCreated(
            [EventMessage] CommentLikeOwnCreatedEvent evt) => evt;

        [Subscribe]
        public CommentLikeOwnUpdatedEvent OnLikeOwnUpdated(
            [EventMessage] CommentLikeOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public CommentLikeOwnDeletedEvent OnLikeOwnDeleted(
            [EventMessage] CommentLikeOwnDeletedEvent evt) => evt;

        [Subscribe]
        public CommentLikeOwnChangedEvent OnLikeOwnChanged(
            [EventMessage] CommentLikeOwnChangedEvent evt) => evt;
    }
}

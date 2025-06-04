using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class CommentLikeSelfSubscription
    {
        [Subscribe]
        public CommentLikeSelfCreatedEvent OnLikeSelfCreated(
            [EventMessage] CommentLikeSelfCreatedEvent evt) => evt;

        [Subscribe]
        public CommentLikeSelfUpdatedEvent OnLikeSelfUpdated(
            [EventMessage] CommentLikeSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public CommentLikeSelfDeletedEvent OnLikeSelfDeleted(
            [EventMessage] CommentLikeSelfDeletedEvent evt) => evt;

        [Subscribe]
        public CommentLikeSelfChangedEvent OnLikeSelfChanged(
            [EventMessage] CommentLikeSelfChangedEvent evt) => evt;
    }
}

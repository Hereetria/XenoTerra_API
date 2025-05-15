using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class CommentSubscription
    {
        [Subscribe]
        public CommentCreatedEvent OnCommentCreated(
            [EventMessage] CommentCreatedEvent evt) => evt;

        [Subscribe]
        public CommentUpdatedEvent OnCommentUpdated(
            [EventMessage] CommentUpdatedEvent evt) => evt;

        [Subscribe]
        public CommentDeletedEvent OnCommentDeleted(
            [EventMessage] CommentDeletedEvent evt) => evt;

        [Subscribe]
        public CommentChangedEvent OnCommentChanged(
            [EventMessage] CommentChangedEvent evt) => evt;
    }
}

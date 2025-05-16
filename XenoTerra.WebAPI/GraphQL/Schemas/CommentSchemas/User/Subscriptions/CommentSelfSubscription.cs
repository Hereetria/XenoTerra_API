using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class CommentSelfSubscription
    {
        [Subscribe]
        public CommentCreatedSelfEvent OnCommentCreated(
            [EventMessage] CommentCreatedSelfEvent evt) => evt;

        [Subscribe]
        public CommentUpdatedSelfEvent OnCommentUpdated(
            [EventMessage] CommentUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public CommentDeletedSelfEvent OnCommentDeleted(
            [EventMessage] CommentDeletedSelfEvent evt) => evt;

        [Subscribe]
        public CommentChangedSelfEvent OnCommentChanged(
            [EventMessage] CommentChangedSelfEvent evt) => evt;
    }
}

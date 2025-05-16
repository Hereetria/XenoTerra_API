using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class CommentAdminSubscription
    {
        [Subscribe]
        public CommentCreatedAdminEvent OnCommentCreated(
            [EventMessage] CommentCreatedAdminEvent evt) => evt;

        [Subscribe]
        public CommentUpdatedAdminEvent OnCommentUpdated(
            [EventMessage] CommentUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public CommentDeletedAdminEvent OnCommentDeleted(
            [EventMessage] CommentDeletedAdminEvent evt) => evt;

        [Subscribe]
        public CommentChangedAdminEvent OnCommentChanged(
            [EventMessage] CommentChangedAdminEvent evt) => evt;
    }
}

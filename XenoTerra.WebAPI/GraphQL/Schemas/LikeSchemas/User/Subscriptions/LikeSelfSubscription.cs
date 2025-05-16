using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class LikeSelfSubscription
    {
        [Subscribe]
        public LikeCreatedSelfEvent OnLikeCreated(
            [EventMessage] LikeCreatedSelfEvent evt) => evt;

        [Subscribe]
        public LikeUpdatedSelfEvent OnLikeUpdated(
            [EventMessage] LikeUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public LikeDeletedSelfEvent OnLikeDeleted(
            [EventMessage] LikeDeletedSelfEvent evt) => evt;

        [Subscribe]
        public LikeChangedSelfEvent OnLikeChanged(
            [EventMessage] LikeChangedSelfEvent evt) => evt;
    }
}

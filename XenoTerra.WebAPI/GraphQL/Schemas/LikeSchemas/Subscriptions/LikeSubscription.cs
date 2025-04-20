using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class LikeSubscription
    {
        [Subscribe]
        public LikeCreatedEvent OnLikeCreated(
            [EventMessage] LikeCreatedEvent evt) => evt;

        [Subscribe]
        public LikeUpdatedEvent OnLikeUpdated(
            [EventMessage] LikeUpdatedEvent evt) => evt;

        [Subscribe]
        public LikeDeletedEvent OnLikeDeleted(
            [EventMessage] LikeDeletedEvent evt) => evt;

        [Subscribe]
        public LikeChangedEvent OnLikeChanged(
            [EventMessage] LikeChangedEvent evt) => evt;
    }
}

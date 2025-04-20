using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class UserPostTagSubscription
    {
        [Subscribe]
        public UserPostTagCreatedEvent OnUserPostTagCreated(
            [EventMessage] UserPostTagCreatedEvent evt) => evt;

        [Subscribe]
        public UserPostTagUpdatedEvent OnUserPostTagUpdated(
            [EventMessage] UserPostTagUpdatedEvent evt) => evt;

        [Subscribe]
        public UserPostTagDeletedEvent OnUserPostTagDeleted(
            [EventMessage] UserPostTagDeletedEvent evt) => evt;

        [Subscribe]
        public UserPostTagChangedEvent OnUserPostTagChanged(
            [EventMessage] UserPostTagChangedEvent evt) => evt;
    }
}

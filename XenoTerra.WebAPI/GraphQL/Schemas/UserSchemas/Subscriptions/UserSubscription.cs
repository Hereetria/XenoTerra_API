using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class UserSubscription
    {
        [Subscribe]
        public UserCreatedEvent OnUserCreated(
            [EventMessage] UserCreatedEvent evt) => evt;

        [Subscribe]
        public UserUpdatedEvent OnUserUpdated(
            [EventMessage] UserUpdatedEvent evt) => evt;

        [Subscribe]
        public UserDeletedEvent OnUserDeleted(
            [EventMessage] UserDeletedEvent evt) => evt;

        [Subscribe]
        public UserChangedEvent OnUserChanged(
            [EventMessage] UserChangedEvent evt) => evt;
    }
}

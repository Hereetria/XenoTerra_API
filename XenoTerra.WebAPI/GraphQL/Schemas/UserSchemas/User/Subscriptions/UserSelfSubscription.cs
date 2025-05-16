using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class UserSelfSubscription
    {
        [Subscribe]
        public UserCreatedSelfEvent OnUserCreated(
            [EventMessage] UserCreatedSelfEvent evt) => evt;

        [Subscribe]
        public UserUpdatedSelfEvent OnUserUpdated(
            [EventMessage] UserUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public UserDeletedSelfEvent OnUserDeleted(
            [EventMessage] UserDeletedSelfEvent evt) => evt;

        [Subscribe]
        public UserChangedSelfEvent OnUserChanged(
            [EventMessage] UserChangedSelfEvent evt) => evt;
    }
}

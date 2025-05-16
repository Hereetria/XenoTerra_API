using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class UserAdminSubscription
    {
        [Subscribe]
        public UserCreatedAdminEvent OnUserCreated(
            [EventMessage] UserCreatedAdminEvent evt) => evt;

        [Subscribe]
        public UserUpdatedAdminEvent OnUserUpdated(
            [EventMessage] UserUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public UserDeletedAdminEvent OnUserDeleted(
            [EventMessage] UserDeletedAdminEvent evt) => evt;

        [Subscribe]
        public UserChangedAdminEvent OnUserChanged(
            [EventMessage] UserChangedAdminEvent evt) => evt;
    }
}

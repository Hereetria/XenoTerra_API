using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class UserPostTagAdminSubscription
    {
        [Subscribe]
        public UserPostTagCreatedAdminEvent OnUserPostTagCreated(
            [EventMessage] UserPostTagCreatedAdminEvent evt) => evt;

        [Subscribe]
        public UserPostTagUpdatedAdminEvent OnUserPostTagUpdated(
            [EventMessage] UserPostTagUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public UserPostTagDeletedAdminEvent OnUserPostTagDeleted(
            [EventMessage] UserPostTagDeletedAdminEvent evt) => evt;

        [Subscribe]
        public UserPostTagChangedAdminEvent OnUserPostTagChanged(
            [EventMessage] UserPostTagChangedAdminEvent evt) => evt;
    }
}

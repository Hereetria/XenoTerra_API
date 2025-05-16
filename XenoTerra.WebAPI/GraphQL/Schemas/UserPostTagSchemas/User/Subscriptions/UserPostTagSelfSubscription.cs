using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class UserPostTagSelfSubscription
    {
        [Subscribe]
        public UserPostTagCreatedSelfEvent OnUserPostTagCreated(
            [EventMessage] UserPostTagCreatedSelfEvent evt) => evt;

        [Subscribe]
        public UserPostTagUpdatedSelfEvent OnUserPostTagUpdated(
            [EventMessage] UserPostTagUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public UserPostTagDeletedSelfEvent OnUserPostTagDeleted(
            [EventMessage] UserPostTagDeletedSelfEvent evt) => evt;

        [Subscribe]
        public UserPostTagChangedSelfEvent OnUserPostTagChanged(
            [EventMessage] UserPostTagChangedSelfEvent evt) => evt;
    }
}

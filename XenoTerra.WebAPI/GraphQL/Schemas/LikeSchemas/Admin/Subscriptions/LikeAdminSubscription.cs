using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class LikeAdminSubscription
    {
        [Subscribe]
        public LikeCreatedAdminEvent OnLikeCreated(
            [EventMessage] LikeCreatedAdminEvent evt) => evt;

        [Subscribe]
        public LikeUpdatedAdminEvent OnLikeUpdated(
            [EventMessage] LikeUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public LikeDeletedAdminEvent OnLikeDeleted(
            [EventMessage] LikeDeletedAdminEvent evt) => evt;

        [Subscribe]
        public LikeChangedAdminEvent OnLikeChanged(
            [EventMessage] LikeChangedAdminEvent evt) => evt;
    }
}

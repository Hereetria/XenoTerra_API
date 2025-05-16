using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class FollowAdminSubscription
    {
        [Subscribe]
        public FollowCreatedAdminEvent OnFollowCreated(
            [EventMessage] FollowCreatedAdminEvent evt) => evt;

        [Subscribe]
        public FollowUpdatedAdminEvent OnFollowUpdated(
            [EventMessage] FollowUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public FollowDeletedAdminEvent OnFollowDeleted(
            [EventMessage] FollowDeletedAdminEvent evt) => evt;

        [Subscribe]
        public FollowChangedAdminEvent OnFollowChanged(
            [EventMessage] FollowChangedAdminEvent evt) => evt;
    }
}

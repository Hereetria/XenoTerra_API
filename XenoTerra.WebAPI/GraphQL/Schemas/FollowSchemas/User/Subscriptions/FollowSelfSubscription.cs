using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class FollowSelfSubscription
    {
        [Subscribe]
        public FollowCreatedSelfEvent OnFollowCreated(
            [EventMessage] FollowCreatedSelfEvent evt) => evt;

        [Subscribe]
        public FollowUpdatedSelfEvent OnFollowUpdated(
            [EventMessage] FollowUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public FollowDeletedSelfEvent OnFollowDeleted(
            [EventMessage] FollowDeletedSelfEvent evt) => evt;

        [Subscribe]
        public FollowChangedSelfEvent OnFollowChanged(
            [EventMessage] FollowChangedSelfEvent evt) => evt;
    }
}

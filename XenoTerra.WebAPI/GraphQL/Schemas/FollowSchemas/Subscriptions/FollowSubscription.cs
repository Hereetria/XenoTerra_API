using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class FollowSubscription
    {
        [Subscribe]
        public FollowCreatedEvent OnFollowCreated(
            [EventMessage] FollowCreatedEvent evt) => evt;

        [Subscribe]
        public FollowUpdatedEvent OnFollowUpdated(
            [EventMessage] FollowUpdatedEvent evt) => evt;

        [Subscribe]
        public FollowDeletedEvent OnFollowDeleted(
            [EventMessage] FollowDeletedEvent evt) => evt;

        [Subscribe]
        public FollowChangedEvent OnFollowChanged(
            [EventMessage] FollowChangedEvent evt) => evt;
    }
}

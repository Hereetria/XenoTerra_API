using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class ReactionSubscription
    {
        [Subscribe]
        public ReactionCreatedEvent OnReactionCreated(
            [EventMessage] ReactionCreatedEvent evt) => evt;

        [Subscribe]
        public ReactionUpdatedEvent OnReactionUpdated(
            [EventMessage] ReactionUpdatedEvent evt) => evt;

        [Subscribe]
        public ReactionDeletedEvent OnReactionDeleted(
            [EventMessage] ReactionDeletedEvent evt) => evt;

        [Subscribe]
        public ReactionChangedEvent OnReactionChanged(
            [EventMessage] ReactionChangedEvent evt) => evt;
    }
}

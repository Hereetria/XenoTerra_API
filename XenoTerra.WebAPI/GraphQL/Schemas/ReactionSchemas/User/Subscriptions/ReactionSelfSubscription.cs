using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class ReactionSelfSubscription
    {
        [Subscribe]
        public ReactionCreatedSelfEvent OnReactionCreated(
            [EventMessage] ReactionCreatedSelfEvent evt) => evt;

        [Subscribe]
        public ReactionUpdatedSelfEvent OnReactionUpdated(
            [EventMessage] ReactionUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public ReactionDeletedSelfEvent OnReactionDeleted(
            [EventMessage] ReactionDeletedSelfEvent evt) => evt;

        [Subscribe]
        public ReactionChangedSelfEvent OnReactionChanged(
            [EventMessage] ReactionChangedSelfEvent evt) => evt;
    }
}

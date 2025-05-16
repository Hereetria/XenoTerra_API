using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class ReactionAdminSubscription
    {
        [Subscribe]
        public ReactionCreatedAdminEvent OnReactionCreated(
            [EventMessage] ReactionCreatedAdminEvent evt) => evt;

        [Subscribe]
        public ReactionUpdatedAdminEvent OnReactionUpdated(
            [EventMessage] ReactionUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public ReactionDeletedAdminEvent OnReactionDeleted(
            [EventMessage] ReactionDeletedAdminEvent evt) => evt;

        [Subscribe]
        public ReactionChangedAdminEvent OnReactionChanged(
            [EventMessage] ReactionChangedAdminEvent evt) => evt;
    }
}

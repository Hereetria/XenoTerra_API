using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReactionOwnSubscription
    {
        [Subscribe]
        public ReactionOwnCreatedEvent OnReactionOwnCreated(
            [EventMessage] ReactionOwnCreatedEvent evt) => evt;

        [Subscribe]
        public ReactionOwnUpdatedEvent OnReactionOwnUpdated(
            [EventMessage] ReactionOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public ReactionOwnDeletedEvent OnReactionOwnDeleted(
            [EventMessage] ReactionOwnDeletedEvent evt) => evt;

        [Subscribe]
        public ReactionOwnChangedEvent OnReactionOwnChanged(
            [EventMessage] ReactionOwnChangedEvent evt) => evt;
    }
}

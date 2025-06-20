using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class HighlightOwnSubscription
    {
        [Subscribe]
        public HighlightOwnCreatedEvent OnHighlightOwnCreated(
            [EventMessage] HighlightOwnCreatedEvent evt) => evt;

        [Subscribe]
        public HighlightOwnUpdatedEvent OnHighlightOwnUpdated(
            [EventMessage] HighlightOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public HighlightOwnDeletedEvent OnHighlightOwnDeleted(
            [EventMessage] HighlightOwnDeletedEvent evt) => evt;

        [Subscribe]
        public HighlightOwnChangedEvent OnHighlightOwnChanged(
            [EventMessage] HighlightOwnChangedEvent evt) => evt;
    }
}

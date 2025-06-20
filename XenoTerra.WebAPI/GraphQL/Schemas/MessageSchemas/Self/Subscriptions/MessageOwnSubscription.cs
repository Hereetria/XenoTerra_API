using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class MessageOwnSubscription
    {
        [Subscribe]
        public MessageOwnCreatedEvent OnMessageOwnCreated(
            [EventMessage] MessageOwnCreatedEvent evt) => evt;

        [Subscribe]
        public MessageOwnUpdatedEvent OnMessageOwnUpdated(
            [EventMessage] MessageOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public MessageOwnDeletedEvent OnMessageOwnDeleted(
            [EventMessage] MessageOwnDeletedEvent evt) => evt;

        [Subscribe]
        public MessageOwnChangedEvent OnMessageOwnChanged(
            [EventMessage] MessageOwnChangedEvent evt) => evt;
    }
}

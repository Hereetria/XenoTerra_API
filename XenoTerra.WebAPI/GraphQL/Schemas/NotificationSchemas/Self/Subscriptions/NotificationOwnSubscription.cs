using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class NotificationOwnSubscription
    {
        [Subscribe]
        public NotificationOwnCreatedEvent OnNotificationOwnCreated(
            [EventMessage] NotificationOwnCreatedEvent evt) => evt;

        [Subscribe]
        public NotificationOwnUpdatedEvent OnNotificationOwnUpdated(
            [EventMessage] NotificationOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public NotificationOwnDeletedEvent OnNotificationOwnDeleted(
            [EventMessage] NotificationOwnDeletedEvent evt) => evt;

        [Subscribe]
        public NotificationOwnChangedEvent OnNotificationOwnChanged(
            [EventMessage] NotificationOwnChangedEvent evt) => evt;
    }
}

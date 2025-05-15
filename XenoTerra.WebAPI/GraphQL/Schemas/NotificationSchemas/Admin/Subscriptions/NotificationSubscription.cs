using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class NotificationSubscription
    {
        [Subscribe]
        public NotificationCreatedEvent OnNotificationCreated(
            [EventMessage] NotificationCreatedEvent evt) => evt;

        [Subscribe]
        public NotificationUpdatedEvent OnNotificationUpdated(
            [EventMessage] NotificationUpdatedEvent evt) => evt;

        [Subscribe]
        public NotificationDeletedEvent OnNotificationDeleted(
            [EventMessage] NotificationDeletedEvent evt) => evt;

        [Subscribe]
        public NotificationChangedEvent OnNotificationChanged(
            [EventMessage] NotificationChangedEvent evt) => evt;
    }
}

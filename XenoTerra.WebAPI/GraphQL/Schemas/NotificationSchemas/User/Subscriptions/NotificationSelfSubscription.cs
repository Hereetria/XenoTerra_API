using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class NotificationSelfSubscription
    {
        [Subscribe]
        public NotificationCreatedSelfEvent OnNotificationCreated(
            [EventMessage] NotificationCreatedSelfEvent evt) => evt;

        [Subscribe]
        public NotificationUpdatedSelfEvent OnNotificationUpdated(
            [EventMessage] NotificationUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public NotificationDeletedSelfEvent OnNotificationDeleted(
            [EventMessage] NotificationDeletedSelfEvent evt) => evt;

        [Subscribe]
        public NotificationChangedSelfEvent OnNotificationChanged(
            [EventMessage] NotificationChangedSelfEvent evt) => evt;
    }
}

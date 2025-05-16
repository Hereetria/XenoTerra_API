using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class NotificationAdminSubscription
    {
        [Subscribe]
        public NotificationCreatedAdminEvent OnNotificationCreated(
            [EventMessage] NotificationCreatedAdminEvent evt) => evt;

        [Subscribe]
        public NotificationUpdatedAdminEvent OnNotificationUpdated(
            [EventMessage] NotificationUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public NotificationDeletedAdminEvent OnNotificationDeleted(
            [EventMessage] NotificationDeletedAdminEvent evt) => evt;

        [Subscribe]
        public NotificationChangedAdminEvent OnNotificationChanged(
            [EventMessage] NotificationChangedAdminEvent evt) => evt;
    }
}

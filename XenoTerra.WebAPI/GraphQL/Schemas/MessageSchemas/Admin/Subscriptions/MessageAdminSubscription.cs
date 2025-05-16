using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class MessageAdminSubscription
    {
        [Subscribe]
        public MessageCreatedAdminEvent OnMessageCreated(
            [EventMessage] MessageCreatedAdminEvent evt) => evt;

        [Subscribe]
        public MessageUpdatedAdminEvent OnMessageUpdated(
            [EventMessage] MessageUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public MessageDeletedAdminEvent OnMessageDeleted(
            [EventMessage] MessageDeletedAdminEvent evt) => evt;

        [Subscribe]
        public MessageChangedAdminEvent OnMessageChanged(
            [EventMessage] MessageChangedAdminEvent evt) => evt;
    }
}

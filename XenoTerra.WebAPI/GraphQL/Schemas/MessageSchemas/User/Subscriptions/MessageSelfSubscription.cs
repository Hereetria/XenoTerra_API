using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class MessageSelfSubscription
    {
        [Subscribe]
        public MessageCreatedSelfEvent OnMessageCreated(
            [EventMessage] MessageCreatedSelfEvent evt) => evt;

        [Subscribe]
        public MessageUpdatedSelfEvent OnMessageUpdated(
            [EventMessage] MessageUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public MessageDeletedSelfEvent OnMessageDeleted(
            [EventMessage] MessageDeletedSelfEvent evt) => evt;

        [Subscribe]
        public MessageChangedSelfEvent OnMessageChanged(
            [EventMessage] MessageChangedSelfEvent evt) => evt;
    }
}

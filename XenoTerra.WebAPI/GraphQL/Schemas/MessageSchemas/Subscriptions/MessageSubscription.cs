using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class MessageSubscription
    {
        [Subscribe]
        public MessageCreatedEvent OnMessageCreated(
            [EventMessage] MessageCreatedEvent evt) => evt;

        [Subscribe]
        public MessageUpdatedEvent OnMessageUpdated(
            [EventMessage] MessageUpdatedEvent evt) => evt;

        [Subscribe]
        public MessageDeletedEvent OnMessageDeleted(
            [EventMessage] MessageDeletedEvent evt) => evt;

        [Subscribe]
        public MessageChangedEvent OnMessageChanged(
            [EventMessage] MessageChangedEvent evt) => evt;
    }
}

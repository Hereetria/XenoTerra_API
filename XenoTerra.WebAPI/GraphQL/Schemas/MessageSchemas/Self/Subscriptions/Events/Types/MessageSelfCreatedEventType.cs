using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events.Types
{
    public class MessageSelfCreatedEventType : ObjectType<MessageSelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageSelfCreatedEvent> descriptor)
        {
        }
    }
}

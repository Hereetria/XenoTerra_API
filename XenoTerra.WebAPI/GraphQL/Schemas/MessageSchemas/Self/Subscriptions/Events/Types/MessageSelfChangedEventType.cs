using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events.Types
{
    public class MessageSelfChangedEventType : ObjectType<MessageSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageSelfChangedEvent> descriptor)
        {
        }
    }
}

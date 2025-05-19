using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events.Types
{
    public class MessageSelfDeletedEventType : ObjectType<MessageSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageSelfDeletedEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events.Types
{
    public class MessageSelfUpdatedEventType : ObjectType<MessageSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageSelfUpdatedEvent> descriptor)
        {
        }
    }
}

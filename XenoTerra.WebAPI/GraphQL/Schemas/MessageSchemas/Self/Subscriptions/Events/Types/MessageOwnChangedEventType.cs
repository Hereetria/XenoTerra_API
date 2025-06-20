using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events.Types
{
    public class MessageOwnChangedEventType : ObjectType<MessageOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageOwnChangedEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events.Types
{
    public class MessageOwnCreatedEventType : ObjectType<MessageOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageOwnCreatedEvent> descriptor)
        {
        }
    }
}

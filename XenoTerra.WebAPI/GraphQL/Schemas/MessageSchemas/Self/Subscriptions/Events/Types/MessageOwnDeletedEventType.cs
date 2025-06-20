using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Self.Subscriptions.Events.Types
{
    public class MessageOwnDeletedEventType : ObjectType<MessageOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageOwnDeletedEvent> descriptor)
        {
        }
    }
}

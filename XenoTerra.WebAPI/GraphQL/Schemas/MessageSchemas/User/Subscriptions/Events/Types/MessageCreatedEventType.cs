using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events.Types
{
    public class MessageCreatedEventType : ObjectType<MessageCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageCreatedEvent> descriptor)
        {
        }
    }
}

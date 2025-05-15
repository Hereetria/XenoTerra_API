using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events.Types
{
    public class MessageDeletedEventType : ObjectType<MessageDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageDeletedEvent> descriptor)
        {
        }
    }
}

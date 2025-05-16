using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events.Types
{
    public class MessageDeletedEventType : ObjectType<MessageDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageDeletedSelfEvent> descriptor)
        {
        }
    }
}

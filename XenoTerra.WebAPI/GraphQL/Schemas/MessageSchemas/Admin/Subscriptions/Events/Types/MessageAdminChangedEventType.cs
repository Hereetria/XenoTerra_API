using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events.Types
{
    public class MessageAdminChangedEventType : ObjectType<MessageAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageAdminChangedEvent> descriptor)
        {
        }
    }
}

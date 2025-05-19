using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events.Types
{
    public class MessageAdminUpdatedEventType : ObjectType<MessageAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageAdminUpdatedEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events.Types
{
    public class MessageUpdatedEventType : ObjectType<MessageUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageUpdatedAdminEvent> descriptor)
        {
        }
    }
}

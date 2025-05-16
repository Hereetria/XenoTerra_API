using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events.Types
{
    public class MessageCreatedEventType : ObjectType<MessageCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageCreatedAdminEvent> descriptor)
        {
        }
    }
}

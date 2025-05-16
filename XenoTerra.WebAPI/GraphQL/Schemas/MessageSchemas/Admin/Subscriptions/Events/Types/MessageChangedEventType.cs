using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events.Types
{
    public class MessageChangedEventType : ObjectType<MessageChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageChangedAdminEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events.Types
{
    public class MessageUpdatedEventType : ObjectType<MessageUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageUpdatedSelfEvent> descriptor)
        {
        }
    }
}

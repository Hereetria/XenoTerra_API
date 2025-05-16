using XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MessageSchemas.Admin.Subscriptions.Events.Types
{
    public class MessageCreatedEventType : ObjectType<MessageCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageCreatedSelfEvent> descriptor)
        {
        }
    }
}

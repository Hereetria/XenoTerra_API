using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events.Types
{
    public class NotificationDeletedEventType : ObjectType<NotificationDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationDeletedSelfEvent> descriptor)
        {
        }
    }
}
using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events.Types
{
    public class NotificationChangedEventType : ObjectType<NotificationChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationChangedSelfEvent> descriptor)
        {
        }
    }
}
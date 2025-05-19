using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events.Types
{
    public class NotificationAdminChangedEventType : ObjectType<NotificationAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationAdminChangedEvent> descriptor)
        {
        }
    }
}
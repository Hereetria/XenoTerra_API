using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events.Types
{
    public class NotificationAdminDeletedEventType : ObjectType<NotificationAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationAdminDeletedEvent> descriptor)
        {
        }
    }
}
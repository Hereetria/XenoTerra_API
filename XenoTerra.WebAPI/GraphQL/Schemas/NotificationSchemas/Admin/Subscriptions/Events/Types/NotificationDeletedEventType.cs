using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events.Types
{
    public class NotificationDeletedEventType : ObjectType<NotificationDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationDeletedAdminEvent> descriptor)
        {
        }
    }
}
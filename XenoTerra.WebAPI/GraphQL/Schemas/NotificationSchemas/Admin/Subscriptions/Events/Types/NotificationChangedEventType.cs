using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events.Types
{
    public class NotificationChangedEventType : ObjectType<NotificationChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationChangedAdminEvent> descriptor)
        {
        }
    }
}
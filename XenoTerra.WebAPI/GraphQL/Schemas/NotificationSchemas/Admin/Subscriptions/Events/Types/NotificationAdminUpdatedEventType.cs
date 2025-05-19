using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events.Types
{
    public class NotificationAdminUpdatedEventType : ObjectType<NotificationAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationAdminUpdatedEvent> descriptor)
        {
        }
    }
}
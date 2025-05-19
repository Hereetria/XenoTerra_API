using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events.Types
{
    public class NotificationAdminCreatedEventType : ObjectType<NotificationAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationAdminCreatedEvent> descriptor)
        {
        }
    }
}
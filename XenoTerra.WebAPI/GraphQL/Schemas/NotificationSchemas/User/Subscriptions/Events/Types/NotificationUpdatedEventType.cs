using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events.Types
{
    public class NotificationUpdatedEventType : ObjectType<NotificationUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationUpdatedEvent> descriptor)
        {
        }
    }
}
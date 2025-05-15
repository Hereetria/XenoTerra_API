using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events.Types
{
    public class NotificationCreatedEventType : ObjectType<NotificationCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationCreatedEvent> descriptor)
        {
        }
    }
}
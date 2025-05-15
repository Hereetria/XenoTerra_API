using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Admin.Subscriptions.Events.Types
{
    public class NotificationDeletedEventType : ObjectType<NotificationDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationDeletedEvent> descriptor)
        {
        }
    }
}
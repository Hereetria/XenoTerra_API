using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events.Types
{
    public class NotificationSelfDeletedEventType : ObjectType<NotificationSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationSelfDeletedEvent> descriptor)
        {
        }
    }
}
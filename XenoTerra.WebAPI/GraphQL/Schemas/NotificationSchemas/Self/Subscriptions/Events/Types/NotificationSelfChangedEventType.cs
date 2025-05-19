using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events.Types
{
    public class NotificationSelfChangedEventType : ObjectType<NotificationSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationSelfChangedEvent> descriptor)
        {
        }
    }
}
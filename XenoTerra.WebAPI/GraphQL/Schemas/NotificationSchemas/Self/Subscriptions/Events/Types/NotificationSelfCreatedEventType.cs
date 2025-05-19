using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events.Types
{
    public class NotificationSelfCreatedEventType : ObjectType<NotificationSelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationSelfCreatedEvent> descriptor)
        {
        }
    }
}
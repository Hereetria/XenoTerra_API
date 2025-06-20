using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events.Types
{
    public class NotificationOwnCreatedEventType : ObjectType<NotificationOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationOwnCreatedEvent> descriptor)
        {
        }
    }
}
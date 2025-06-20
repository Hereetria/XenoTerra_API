using XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NotificationSchemas.Self.Subscriptions.Events.Types
{
    public class NotificationOwnUpdatedEventType : ObjectType<NotificationOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<NotificationOwnUpdatedEvent> descriptor)
        {
        }
    }
}
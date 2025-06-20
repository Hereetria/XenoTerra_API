using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events.Types
{
    public class MediaOwnUpdatedEventType : ObjectType<MediaOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaOwnUpdatedEvent> descriptor)
        {
        }
    }
}

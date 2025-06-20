using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events.Types
{
    public class MediaOwnCreatedEventType : ObjectType<MediaOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaOwnCreatedEvent> descriptor)
        {
        }
    }
}

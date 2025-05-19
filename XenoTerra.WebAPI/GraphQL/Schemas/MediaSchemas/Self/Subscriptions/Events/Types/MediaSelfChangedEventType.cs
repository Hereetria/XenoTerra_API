using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events.Types
{
    public class MediaSelfChangedEventType : ObjectType<MediaSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaSelfChangedEvent> descriptor)
        {
        }
    }
}

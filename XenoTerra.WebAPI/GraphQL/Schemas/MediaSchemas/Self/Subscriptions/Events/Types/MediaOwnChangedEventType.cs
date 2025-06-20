using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events.Types
{
    public class MediaOwnChangedEventType : ObjectType<MediaOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaOwnChangedEvent> descriptor)
        {
        }
    }
}

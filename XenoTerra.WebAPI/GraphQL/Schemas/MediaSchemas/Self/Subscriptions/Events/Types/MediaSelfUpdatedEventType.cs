using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events.Types
{
    public class MediaSelfUpdatedEventType : ObjectType<MediaSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaSelfUpdatedEvent> descriptor)
        {
        }
    }
}

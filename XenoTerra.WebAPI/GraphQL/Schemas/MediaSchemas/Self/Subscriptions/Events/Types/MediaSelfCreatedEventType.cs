using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events.Types
{
    public class MediaSelfCreatedEventType : ObjectType<MediaSelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaSelfCreatedEvent> descriptor)
        {
        }
    }
}

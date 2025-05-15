using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaCreatedEventType : ObjectType<MediaCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaCreatedEvent> descriptor)
        {
        }
    }
}

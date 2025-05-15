using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaUpdatedEventType : ObjectType<MediaUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaUpdatedEvent> descriptor)
        {
        }
    }
}

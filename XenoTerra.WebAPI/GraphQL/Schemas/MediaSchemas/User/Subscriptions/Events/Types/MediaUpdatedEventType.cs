using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaUpdatedEventType : ObjectType<MediaUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaUpdatedSelfEvent> descriptor)
        {
        }
    }
}

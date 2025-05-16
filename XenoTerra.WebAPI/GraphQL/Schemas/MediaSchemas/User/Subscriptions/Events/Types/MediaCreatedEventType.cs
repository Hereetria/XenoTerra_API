using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaCreatedEventType : ObjectType<MediaCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaCreatedSelfEvent> descriptor)
        {
        }
    }
}

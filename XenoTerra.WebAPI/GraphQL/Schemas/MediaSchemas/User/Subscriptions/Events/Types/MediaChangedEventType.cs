using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaChangedEventType : ObjectType<MediaChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaChangedSelfEvent> descriptor)
        {
        }
    }
}

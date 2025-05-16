using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaDeletedEventType : ObjectType<MediaDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaDeletedSelfEvent> descriptor)
        {
        }
    }
}

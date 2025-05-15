using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaChangedEventType : ObjectType<MediaChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaChangedEvent> descriptor)
        {
        }
    }
}

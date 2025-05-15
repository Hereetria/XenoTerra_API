using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaDeletedEventType : ObjectType<MediaDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaDeletedEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaAdminChangedEventType : ObjectType<MediaAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaAdminChangedEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaAdminDeletedEventType : ObjectType<MediaAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaAdminDeletedEvent> descriptor)
        {
        }
    }
}

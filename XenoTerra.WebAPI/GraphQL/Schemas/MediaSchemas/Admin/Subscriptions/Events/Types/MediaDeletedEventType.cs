using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaDeletedEventType : ObjectType<MediaDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaDeletedAdminEvent> descriptor)
        {
        }
    }
}

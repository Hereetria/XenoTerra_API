using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaUpdatedEventType : ObjectType<MediaUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaUpdatedAdminEvent> descriptor)
        {
        }
    }
}

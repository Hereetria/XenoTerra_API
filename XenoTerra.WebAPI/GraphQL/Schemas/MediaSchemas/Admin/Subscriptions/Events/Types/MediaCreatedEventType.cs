using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaCreatedEventType : ObjectType<MediaCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaCreatedAdminEvent> descriptor)
        {
        }
    }
}

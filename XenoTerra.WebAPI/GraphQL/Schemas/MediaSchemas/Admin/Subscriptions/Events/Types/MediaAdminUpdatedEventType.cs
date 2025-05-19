using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaAdminUpdatedEventType : ObjectType<MediaAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaAdminUpdatedEvent> descriptor)
        {
        }
    }
}

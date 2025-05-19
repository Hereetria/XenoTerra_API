using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaAdminCreatedEventType : ObjectType<MediaAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaAdminCreatedEvent> descriptor)
        {
        }
    }
}

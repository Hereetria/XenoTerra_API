using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events.Types
{
    public class MediaChangedEventType : ObjectType<MediaChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<MediaChangedAdminEvent> descriptor)
        {
        }
    }
}

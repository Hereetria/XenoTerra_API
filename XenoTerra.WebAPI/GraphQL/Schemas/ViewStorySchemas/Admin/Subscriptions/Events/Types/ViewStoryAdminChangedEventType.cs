using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Subscriptions.Events.Types
{
    public class ViewStoryAdminChangedEventType : ObjectType<ViewStoryAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStoryAdminChangedEvent> descriptor)
        {
        }
    }
}

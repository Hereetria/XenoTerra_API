using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Subscriptions.Events.Types
{
    public class ViewStoryAdminDeletedEventType : ObjectType<ViewStoryAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStoryAdminDeletedEvent> descriptor)
        {
        }
    }
}

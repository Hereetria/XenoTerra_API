using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Subscriptions.Events.Types
{
    public class ViewStoryAdminUpdatedEventType : ObjectType<ViewStoryAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStoryAdminUpdatedEvent> descriptor)
        {
        }
    }
}

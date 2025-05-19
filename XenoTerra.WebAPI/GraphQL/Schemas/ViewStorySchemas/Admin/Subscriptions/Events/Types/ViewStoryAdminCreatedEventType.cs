using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Subscriptions.Events.Types
{
    public class ViewStoryAdminCreatedEventType : ObjectType<ViewStoryAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ViewStoryAdminCreatedEvent> descriptor)
        {
        }
    }
}

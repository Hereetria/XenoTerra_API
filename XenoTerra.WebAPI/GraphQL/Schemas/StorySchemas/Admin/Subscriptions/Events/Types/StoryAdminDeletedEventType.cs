using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events.Types
{
    public class StoryAdminDeletedEventType : ObjectType<StoryAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryAdminDeletedEvent> descriptor)
        {
        }
    }
}
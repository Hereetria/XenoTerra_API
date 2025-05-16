using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events.Types
{
    public class StoryUpdatedEventType : ObjectType<StoryUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryUpdatedAdminEvent> descriptor)
        {
        }
    }
}
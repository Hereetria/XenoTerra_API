using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events.Types
{
    public class StoryCreatedEventType : ObjectType<StoryCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryCreatedAdminEvent> descriptor)
        {
        }
    }
}
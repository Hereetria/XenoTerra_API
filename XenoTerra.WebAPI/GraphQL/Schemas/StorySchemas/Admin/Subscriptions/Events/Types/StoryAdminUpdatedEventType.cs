using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events.Types
{
    public class StoryAdminUpdatedEventType : ObjectType<StoryAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryAdminUpdatedEvent> descriptor)
        {
        }
    }
}
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events.Types
{
    public class StoryAdminCreatedEventType : ObjectType<StoryAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryAdminCreatedEvent> descriptor)
        {
        }
    }
}
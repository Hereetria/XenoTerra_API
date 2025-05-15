using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events.Types
{
    public class StoryCreatedEventType : ObjectType<StoryCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryCreatedEvent> descriptor)
        {
        }
    }
}
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events.Types
{
    public class StoryCreatedEventType : ObjectType<StoryCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryCreatedSelfEvent> descriptor)
        {
        }
    }
}
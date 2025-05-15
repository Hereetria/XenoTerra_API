using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events.Types
{
    public class StoryChangedEventType : ObjectType<StoryChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryChangedEvent> descriptor)
        {
        }
    }
}
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryHighlightChangedEventType : ObjectType<StoryHighlightChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightChangedEvent> descriptor)
        {
        }
    }
}
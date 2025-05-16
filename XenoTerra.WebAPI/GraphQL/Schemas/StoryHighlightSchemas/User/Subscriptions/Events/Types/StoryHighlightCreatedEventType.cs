using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryHighlightCreatedEventType : ObjectType<StoryHighlightCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightCreatedSelfEvent> descriptor)
        {
        }
    }
}
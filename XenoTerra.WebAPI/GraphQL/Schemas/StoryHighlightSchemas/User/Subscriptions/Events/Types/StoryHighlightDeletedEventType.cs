using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryHighlightDeletedEventType : ObjectType<StoryHighlightDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightDeletedSelfEvent> descriptor)
        {
        }
    }
}
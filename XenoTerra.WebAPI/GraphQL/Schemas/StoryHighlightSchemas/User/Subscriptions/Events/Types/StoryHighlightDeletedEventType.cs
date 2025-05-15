using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryHighlightDeletedEventType : ObjectType<StoryHighlightDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightDeletedEvent> descriptor)
        {
        }
    }
}
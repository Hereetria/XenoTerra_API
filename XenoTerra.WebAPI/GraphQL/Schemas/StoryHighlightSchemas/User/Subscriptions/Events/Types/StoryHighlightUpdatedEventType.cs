using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryHighlightUpdatedEventType : ObjectType<StoryHighlightUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightUpdatedEvent> descriptor)
        {
        }
    }
}
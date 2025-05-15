using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryHighlightCreatedEventType : ObjectType<StoryHighlightCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightCreatedEvent> descriptor)
        {
        }
    }
}
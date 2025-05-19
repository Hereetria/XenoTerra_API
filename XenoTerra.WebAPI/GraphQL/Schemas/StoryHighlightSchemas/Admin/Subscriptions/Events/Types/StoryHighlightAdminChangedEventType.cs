using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryHighlightAdminChangedEventType : ObjectType<StoryHighlightAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightAdminChangedEvent> descriptor)
        {
        }
    }
}
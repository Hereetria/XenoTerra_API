using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryHighlightChangedEventType : ObjectType<StoryHighlightChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightChangedAdminEvent> descriptor)
        {
        }
    }
}
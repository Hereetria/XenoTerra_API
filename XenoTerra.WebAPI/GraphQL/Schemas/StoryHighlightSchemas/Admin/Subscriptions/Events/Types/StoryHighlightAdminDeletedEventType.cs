using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryHighlightAdminDeletedEventType : ObjectType<StoryHighlightAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightAdminDeletedEvent> descriptor)
        {
        }
    }
}
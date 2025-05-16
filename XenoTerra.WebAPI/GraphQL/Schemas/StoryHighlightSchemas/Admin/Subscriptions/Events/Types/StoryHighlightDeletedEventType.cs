using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryHighlightDeletedEventType : ObjectType<StoryHighlightDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightDeletedAdminEvent> descriptor)
        {
        }
    }
}
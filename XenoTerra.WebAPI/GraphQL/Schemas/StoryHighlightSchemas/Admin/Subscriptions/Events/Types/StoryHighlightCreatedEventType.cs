using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryHighlightCreatedEventType : ObjectType<StoryHighlightCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightCreatedAdminEvent> descriptor)
        {
        }
    }
}
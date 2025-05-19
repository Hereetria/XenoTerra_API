using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryHighlightAdminUpdatedEventType : ObjectType<StoryHighlightAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightAdminUpdatedEvent> descriptor)
        {
        }
    }
}
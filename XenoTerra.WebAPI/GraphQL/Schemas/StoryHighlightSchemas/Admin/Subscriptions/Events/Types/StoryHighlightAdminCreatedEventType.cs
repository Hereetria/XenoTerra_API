using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryHighlightAdminCreatedEventType : ObjectType<StoryHighlightAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryHighlightAdminCreatedEvent> descriptor)
        {
        }
    }
}
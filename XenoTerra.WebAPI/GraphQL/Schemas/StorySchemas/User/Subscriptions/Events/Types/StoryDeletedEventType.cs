using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events.Types
{
    public class StoryDeletedEventType : ObjectType<StoryDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryDeletedSelfEvent> descriptor)
        {
        }
    }
}
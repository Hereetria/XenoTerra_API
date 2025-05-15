using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events.Types
{
    public class StoryDeletedEventType : ObjectType<StoryDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryDeletedEvent> descriptor)
        {
        }
    }
}
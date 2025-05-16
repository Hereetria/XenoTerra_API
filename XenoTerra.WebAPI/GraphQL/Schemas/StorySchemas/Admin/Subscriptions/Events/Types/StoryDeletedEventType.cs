using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events.Types
{
    public class StoryDeletedEventType : ObjectType<StoryDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryDeletedAdminEvent> descriptor)
        {
        }
    }
}
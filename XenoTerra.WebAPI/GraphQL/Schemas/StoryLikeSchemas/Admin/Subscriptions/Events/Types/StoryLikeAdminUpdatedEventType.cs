using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryLikeAdminUpdatedEventType : ObjectType<StoryLikeAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryLikeAdminUpdatedEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryLikeAdminCreatedEventType : ObjectType<StoryLikeAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryLikeAdminCreatedEvent> descriptor)
        {
        }
    }
}

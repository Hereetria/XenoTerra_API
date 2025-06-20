using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryLikeAdminDeletedEventType : ObjectType<StoryLikeAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryLikeAdminDeletedEvent> descriptor)
        {
        }
    }
}

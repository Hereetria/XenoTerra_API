using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Subscriptions.Events.Types
{
    public class StoryLikeAdminChangedEventType : ObjectType<StoryLikeAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryLikeAdminChangedEvent> descriptor)
        {
        }
    }
}

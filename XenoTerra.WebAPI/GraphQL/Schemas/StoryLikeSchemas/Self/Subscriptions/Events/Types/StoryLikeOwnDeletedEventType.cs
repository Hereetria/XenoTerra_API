using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Subscriptions.Events.Types
{
    public class StoryLikeOwnDeletedEventType : ObjectType<StoryLikeOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryLikeOwnDeletedEvent> descriptor)
        {
        }
    }
}

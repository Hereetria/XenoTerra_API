using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Subscriptions.Events.Types
{
    public class StoryLikeOwnChangedEventType : ObjectType<StoryLikeOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryLikeOwnChangedEvent> descriptor)
        {
        }
    }
}

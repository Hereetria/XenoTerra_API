using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Subscriptions.Events.Types
{
    public class StoryLikeOwnUpdatedEventType : ObjectType<StoryLikeOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryLikeOwnUpdatedEvent> descriptor)
        {
        }
    }
}

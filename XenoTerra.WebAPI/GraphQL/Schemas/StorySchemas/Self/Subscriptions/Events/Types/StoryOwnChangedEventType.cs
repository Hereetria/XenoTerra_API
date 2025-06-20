using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events.Types
{
    public class StoryOwnChangedEventType : ObjectType<StoryOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryOwnChangedEvent> descriptor)
        {
        }
    }
}
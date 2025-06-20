using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events.Types
{
    public class StoryOwnUpdatedEventType : ObjectType<StoryOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryOwnUpdatedEvent> descriptor)
        {
        }
    }
}
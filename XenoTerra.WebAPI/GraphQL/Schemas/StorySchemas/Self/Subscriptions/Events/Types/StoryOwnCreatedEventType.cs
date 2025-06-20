using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events.Types
{
    public class StoryOwnCreatedEventType : ObjectType<StoryOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryOwnCreatedEvent> descriptor)
        {
        }
    }
}
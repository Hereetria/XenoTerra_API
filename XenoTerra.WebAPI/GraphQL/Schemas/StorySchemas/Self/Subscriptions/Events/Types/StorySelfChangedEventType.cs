using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events.Types
{
    public class StorySelfChangedEventType : ObjectType<StorySelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StorySelfChangedEvent> descriptor)
        {
        }
    }
}
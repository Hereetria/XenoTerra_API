using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events.Types
{
    public class StorySelfCreatedEventType : ObjectType<StorySelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StorySelfCreatedEvent> descriptor)
        {
        }
    }
}
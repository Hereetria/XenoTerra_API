using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events.Types
{
    public class StoryOwnDeletedEventType : ObjectType<StoryOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<StoryOwnDeletedEvent> descriptor)
        {
        }
    }
}
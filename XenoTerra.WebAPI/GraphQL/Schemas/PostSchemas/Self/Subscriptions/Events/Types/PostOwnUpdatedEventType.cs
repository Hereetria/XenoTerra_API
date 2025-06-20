using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events.Types
{
    public class PostOwnUpdatedEventType : ObjectType<PostOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostOwnUpdatedEvent> descriptor)
        {
        }
    }
}
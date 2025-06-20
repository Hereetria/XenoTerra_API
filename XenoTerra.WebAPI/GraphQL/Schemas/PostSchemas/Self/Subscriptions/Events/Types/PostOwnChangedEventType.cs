using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events.Types
{
    public class PostOwnChangedEventType : ObjectType<PostOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostOwnChangedEvent> descriptor)
        {
        }
    }
}
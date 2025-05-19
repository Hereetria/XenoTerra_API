using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events.Types
{
    public class PostSelfChangedEventType : ObjectType<PostSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostSelfChangedEvent> descriptor)
        {
        }
    }
}
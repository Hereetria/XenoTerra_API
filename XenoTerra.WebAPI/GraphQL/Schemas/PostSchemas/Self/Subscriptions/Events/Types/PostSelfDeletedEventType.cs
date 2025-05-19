using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events.Types
{
    public class PostSelfDeletedEventType : ObjectType<PostSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostSelfDeletedEvent> descriptor)
        {
        }
    }
}
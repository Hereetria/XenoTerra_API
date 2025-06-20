using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events.Types
{
    public class PostLikeOwnUpdatedEventType : ObjectType<PostLikeOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostLikeOwnUpdatedEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events.Types
{
    public class PostLikeSelfChangedEventType : ObjectType<PostLikeSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostLikeSelfChangedEvent> descriptor)
        {
        }
    }
}

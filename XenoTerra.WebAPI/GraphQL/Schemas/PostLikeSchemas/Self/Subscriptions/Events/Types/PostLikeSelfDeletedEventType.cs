using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events.Types
{
    public class PostLikeSelfDeletedEventType : ObjectType<PostLikeSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostLikeSelfDeletedEvent> descriptor)
        {
        }
    }
}

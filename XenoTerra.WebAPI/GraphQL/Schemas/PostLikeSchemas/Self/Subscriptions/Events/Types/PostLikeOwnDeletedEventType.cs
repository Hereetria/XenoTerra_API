using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events.Types
{
    public class PostLikeOwnDeletedEventType : ObjectType<PostLikeOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostLikeOwnDeletedEvent> descriptor)
        {
        }
    }
}

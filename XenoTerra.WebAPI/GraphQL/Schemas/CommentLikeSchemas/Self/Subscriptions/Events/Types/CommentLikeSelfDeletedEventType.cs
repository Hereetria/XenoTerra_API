using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events.Types
{
    public class CommentLikeSelfDeletedEventType : ObjectType<CommentLikeSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikeSelfDeletedEvent> descriptor)
        {
        }
    }
}

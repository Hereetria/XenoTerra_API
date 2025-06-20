using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events.Types
{
    public class CommentLikeOwnDeletedEventType : ObjectType<CommentLikeOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikeOwnDeletedEvent> descriptor)
        {
        }
    }
}

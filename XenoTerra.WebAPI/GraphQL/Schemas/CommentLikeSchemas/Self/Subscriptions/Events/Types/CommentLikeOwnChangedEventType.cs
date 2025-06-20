using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events.Types
{
    public class CommentLikeOwnChangedEventType : ObjectType<CommentLikeOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikeOwnChangedEvent> descriptor)
        {
        }
    }
}

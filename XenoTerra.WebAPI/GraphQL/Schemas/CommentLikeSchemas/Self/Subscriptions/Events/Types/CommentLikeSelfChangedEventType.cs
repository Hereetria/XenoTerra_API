using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events.Types
{
    public class CommentLikeSelfChangedEventType : ObjectType<CommentLikeSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikeSelfChangedEvent> descriptor)
        {
        }
    }
}

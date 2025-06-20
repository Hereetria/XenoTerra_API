using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events.Types
{
    public class CommentLikeOwnUpdatedEventType : ObjectType<CommentLikeOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikeOwnUpdatedEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events.Types
{
    public class CommentLikeOwnCreatedEventType : ObjectType<CommentLikeOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikeOwnCreatedEvent> descriptor)
        {
        }
    }
}

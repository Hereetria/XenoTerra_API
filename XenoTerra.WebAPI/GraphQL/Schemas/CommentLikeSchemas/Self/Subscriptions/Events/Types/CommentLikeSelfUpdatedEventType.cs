using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Self.Subscriptions.Events.Types
{
    public class CommentLikeSelfUpdatedEventType : ObjectType<CommentLikeSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikeSelfUpdatedEvent> descriptor)
        {
        }
    }
}

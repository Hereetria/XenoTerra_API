using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Subscriptions.Events.Types
{
    public class CommentLikeAdminDeletedEventType : ObjectType<CommentLikeAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikeAdminDeletedEvent> descriptor)
        {
        }
    }
}

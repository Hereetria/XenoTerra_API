using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Subscriptions.Events.Types
{
    public class CommentLikeAdminChangedEventType : ObjectType<CommentLikeAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikeAdminChangedEvent> descriptor)
        {
        }
    }
}

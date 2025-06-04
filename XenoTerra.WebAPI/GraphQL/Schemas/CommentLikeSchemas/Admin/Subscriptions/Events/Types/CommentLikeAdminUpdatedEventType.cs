using XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentLikeSchemas.Admin.Subscriptions.Events.Types
{
    public class CommentLikeAdminUpdatedEventType : ObjectType<CommentLikeAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentLikeAdminUpdatedEvent> descriptor)
        {
        }
    }
}

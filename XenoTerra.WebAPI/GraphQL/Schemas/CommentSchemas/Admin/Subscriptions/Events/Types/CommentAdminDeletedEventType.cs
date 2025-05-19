using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events.Types
{
    public class CommentDeletedEventType : ObjectType<CommentAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentAdminDeletedEvent> descriptor)
        {
        }
    }
}

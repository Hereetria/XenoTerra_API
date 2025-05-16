using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events.Types
{
    public class CommentUpdatedEventType : ObjectType<CommentUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentUpdatedAdminEvent> descriptor)
        {
        }
    }
}

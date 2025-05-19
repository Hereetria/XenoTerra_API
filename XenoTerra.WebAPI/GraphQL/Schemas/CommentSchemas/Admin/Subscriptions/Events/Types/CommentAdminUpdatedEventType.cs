using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events.Types
{
    public class CommentUpdatedEventType : ObjectType<CommentAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentAdminUpdatedEvent> descriptor)
        {
        }
    }
}

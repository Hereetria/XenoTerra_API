using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events.Types
{
    public class CommentUpdatedEventType : ObjectType<CommentUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentUpdatedEvent> descriptor)
        {
        }
    }
}

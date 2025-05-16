using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events.Types
{
    public class CommentUpdatedEventType : ObjectType<CommentUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentUpdatedSelfEvent> descriptor)
        {
        }
    }
}

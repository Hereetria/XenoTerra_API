using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events.Types
{
    public class CommentCreatedEventType : ObjectType<CommentCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentCreatedSelfEvent> descriptor)
        {
        }
    }
}

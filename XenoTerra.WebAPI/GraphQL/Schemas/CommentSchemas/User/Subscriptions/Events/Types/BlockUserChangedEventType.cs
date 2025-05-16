using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events.Types
{
    public class CommentChangedEventType : ObjectType<CommentChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentChangedSelfEvent> descriptor)
        {
        }
    }
}

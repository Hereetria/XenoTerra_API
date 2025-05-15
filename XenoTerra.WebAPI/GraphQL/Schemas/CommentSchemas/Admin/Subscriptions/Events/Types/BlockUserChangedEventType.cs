using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events.Types
{
    public class CommentChangedEventType : ObjectType<CommentChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentChangedEvent> descriptor)
        {
        }
    }
}

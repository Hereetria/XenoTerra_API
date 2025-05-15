using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Admin.Subscriptions.Events.Types
{
    public class CommentCreatedEventType : ObjectType<CommentCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentCreatedEvent> descriptor)
        {
        }
    }
}

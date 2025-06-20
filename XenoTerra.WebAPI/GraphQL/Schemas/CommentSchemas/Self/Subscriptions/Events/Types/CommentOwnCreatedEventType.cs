using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events.Types
{
    public class CommentOwnCreatedEventType : ObjectType<CommentOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentOwnCreatedEvent> descriptor)
        {
        }
    }
}

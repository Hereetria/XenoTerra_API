using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events.Types
{
    public class CommentOwnUpdatedEventType : ObjectType<CommentOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentOwnUpdatedEvent> descriptor)
        {
        }
    }
}

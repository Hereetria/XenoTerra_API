using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events.Types
{
    public class CommentOwnChangedEventType : ObjectType<CommentOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentOwnChangedEvent> descriptor)
        {
        }
    }
}

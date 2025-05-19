using XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Self.Subscriptions.Events.Types
{
    public class CommentSelfUpdatedEventType : ObjectType<CommentSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentSelfUpdatedEvent> descriptor)
        {
        }
    }
}

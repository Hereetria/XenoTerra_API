namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Subscriptions.Events.Types
{
    public class CommentUpdatedEventType : ObjectType<CommentUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentUpdatedEvent> descriptor)
        {
        }
    }
}

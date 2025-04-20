namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Subscriptions.Events.Types
{
    public class CommentCreatedEventType : ObjectType<CommentCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentCreatedEvent> descriptor)
        {
        }
    }
}

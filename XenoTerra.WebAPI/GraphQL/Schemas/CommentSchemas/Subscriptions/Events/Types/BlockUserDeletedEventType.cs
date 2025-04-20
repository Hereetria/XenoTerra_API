namespace XenoTerra.WebAPI.GraphQL.Schemas.CommentSchemas.Subscriptions.Events.Types
{
    public class CommentDeletedEventType : ObjectType<CommentDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentDeletedEvent> descriptor)
        {
        }
    }
}

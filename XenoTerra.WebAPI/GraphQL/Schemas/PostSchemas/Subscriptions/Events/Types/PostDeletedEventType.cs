namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Subscriptions.Events.Types
{
    public class PostDeletedEventType : ObjectType<PostDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostDeletedEvent> descriptor)
        {
        }
    }
}
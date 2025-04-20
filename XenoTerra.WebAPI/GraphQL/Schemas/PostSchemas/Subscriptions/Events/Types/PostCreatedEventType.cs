namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Subscriptions.Events.Types
{
    public class PostCreatedEventType : ObjectType<PostCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostCreatedEvent> descriptor)
        {
        }
    }
}
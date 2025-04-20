namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Subscriptions.Events.Types
{
    public class PostUpdatedEventType : ObjectType<PostUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<PostUpdatedEvent> descriptor)
        {
        }
    }
}
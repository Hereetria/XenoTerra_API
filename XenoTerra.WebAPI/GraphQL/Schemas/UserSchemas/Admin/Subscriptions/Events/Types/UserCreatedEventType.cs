namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events.Types
{
    public class UserCreatedEventType : ObjectType<UserCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserCreatedEvent> descriptor)
        {
        }
    }
}

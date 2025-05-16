namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events.Types
{
    public class UserCreatedEventType : ObjectType<UserCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserCreatedSelfEvent> descriptor)
        {
        }
    }
}

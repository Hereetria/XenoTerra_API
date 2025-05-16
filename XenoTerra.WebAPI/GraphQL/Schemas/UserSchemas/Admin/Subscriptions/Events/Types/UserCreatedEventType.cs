namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events.Types
{
    public class UserCreatedEventType : ObjectType<UserCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserCreatedAdminEvent> descriptor)
        {
        }
    }
}

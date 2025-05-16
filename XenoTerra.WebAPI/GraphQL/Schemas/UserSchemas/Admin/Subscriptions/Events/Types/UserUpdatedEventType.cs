namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events.Types
{
    public class UserUpdatedEventType : ObjectType<UserUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserUpdatedAdminEvent> descriptor)
        {
        }
    }
}

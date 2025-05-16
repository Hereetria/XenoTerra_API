namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Subscriptions.Events.Types
{
    public class UserDeletedEventType : ObjectType<UserDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserDeletedAdminEvent> descriptor)
        {
        }
    }
}

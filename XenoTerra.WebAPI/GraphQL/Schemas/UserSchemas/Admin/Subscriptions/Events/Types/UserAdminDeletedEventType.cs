namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Subscriptions.Events.Types
{
    public class UserAdminDeletedEventType : ObjectType<UserAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserAdminDeletedEvent> descriptor)
        {
        }
    }
}

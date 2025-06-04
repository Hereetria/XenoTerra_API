namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Admin.Subscriptions.Events.Types
{
    public class AppUserAdminUpdatedEventType : ObjectType<UserAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserAdminUpdatedEvent> descriptor)
        {
        }
    }
}

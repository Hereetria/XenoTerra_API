using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Subscriptions.Events.Types
{
    public class AppRoleAdminCreatedEventType : ObjectType<RoleAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleAdminCreatedEvent> descriptor)
        {
        }
    }
}
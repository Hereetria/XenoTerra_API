using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Subscriptions.Events.Types
{
    public class AppRoleAdminUpdatedEventType : ObjectType<RoleAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleAdminUpdatedEvent> descriptor)
        {
        }
    }
}
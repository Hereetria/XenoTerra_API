using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Subscriptions.Events.Types
{
    public class AppRoleAdminDeletedEventType : ObjectType<RoleAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleAdminDeletedEvent> descriptor)
        {
        }
    }
}
using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Subscriptions.Events.Types
{
    public class AppRoleAdminChangedEventType : ObjectType<RoleAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleAdminChangedEvent> descriptor)
        {
        }
    }
}
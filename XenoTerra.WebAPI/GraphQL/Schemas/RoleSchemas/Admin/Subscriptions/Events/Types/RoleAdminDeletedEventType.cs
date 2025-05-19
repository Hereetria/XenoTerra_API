using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events.Types
{
    public class RoleAdminDeletedEventType : ObjectType<RoleAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleAdminDeletedEvent> descriptor)
        {
        }
    }
}
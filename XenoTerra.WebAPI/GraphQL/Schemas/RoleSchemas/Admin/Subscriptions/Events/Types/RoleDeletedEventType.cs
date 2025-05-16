using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events.Types
{
    public class RoleDeletedEventType : ObjectType<RoleDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleDeletedAdminEvent> descriptor)
        {
        }
    }
}
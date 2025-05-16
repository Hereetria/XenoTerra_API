using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events.Types
{
    public class RoleCreatedEventType : ObjectType<RoleCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleCreatedAdminEvent> descriptor)
        {
        }
    }
}
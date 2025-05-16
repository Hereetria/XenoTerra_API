using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events.Types
{
    public class RoleUpdatedEventType : ObjectType<RoleUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleUpdatedAdminEvent> descriptor)
        {
        }
    }
}
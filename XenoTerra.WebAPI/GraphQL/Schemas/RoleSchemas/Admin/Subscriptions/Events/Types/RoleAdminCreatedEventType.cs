using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events.Types
{
    public class RoleAdminCreatedEventType : ObjectType<RoleAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleAdminCreatedEvent> descriptor)
        {
        }
    }
}
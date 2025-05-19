using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events.Types
{
    public class RoleAdminUpdatedEventType : ObjectType<RoleAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleAdminUpdatedEvent> descriptor)
        {
        }
    }
}
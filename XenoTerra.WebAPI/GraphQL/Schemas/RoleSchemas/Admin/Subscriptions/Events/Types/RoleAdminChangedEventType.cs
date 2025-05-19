using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events.Types
{
    public class RoleAdminChangedEventType : ObjectType<RoleAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleAdminChangedEvent> descriptor)
        {
        }
    }
}
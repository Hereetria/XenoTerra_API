using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events.Types
{
    public class RoleChangedEventType : ObjectType<RoleChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleChangedAdminEvent> descriptor)
        {
        }
    }
}
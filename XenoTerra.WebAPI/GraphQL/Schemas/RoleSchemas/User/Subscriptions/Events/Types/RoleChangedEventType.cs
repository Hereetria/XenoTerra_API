using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events.Types
{
    public class RoleChangedEventType : ObjectType<RoleChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleChangedEvent> descriptor)
        {
        }
    }
}
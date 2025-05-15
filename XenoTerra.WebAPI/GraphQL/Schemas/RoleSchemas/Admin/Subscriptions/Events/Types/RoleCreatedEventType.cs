using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events.Types
{
    public class RoleCreatedEventType : ObjectType<RoleCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleCreatedEvent> descriptor)
        {
        }
    }
}
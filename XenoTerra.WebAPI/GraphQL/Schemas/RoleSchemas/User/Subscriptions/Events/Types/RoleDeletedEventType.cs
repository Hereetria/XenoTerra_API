using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events.Types
{
    public class RoleDeletedEventType : ObjectType<RoleDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleDeletedEvent> descriptor)
        {
        }
    }
}
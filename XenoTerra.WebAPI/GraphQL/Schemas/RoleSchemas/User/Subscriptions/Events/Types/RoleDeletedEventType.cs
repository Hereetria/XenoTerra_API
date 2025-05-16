using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events.Types
{
    public class RoleDeletedEventType : ObjectType<RoleDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleDeletedSelfEvent> descriptor)
        {
        }
    }
}
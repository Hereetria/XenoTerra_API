using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events.Types
{
    public class RoleCreatedEventType : ObjectType<RoleCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleCreatedSelfEvent> descriptor)
        {
        }
    }
}
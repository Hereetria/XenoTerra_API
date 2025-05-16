using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events.Types
{
    public class RoleChangedEventType : ObjectType<RoleChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RoleChangedSelfEvent> descriptor)
        {
        }
    }
}
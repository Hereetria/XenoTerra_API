using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events.Types
{
    public class BlockUserChangedEventType : ObjectType<BlockUserChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserChangedAdminEvent> descriptor)
        {
        }
    }
}

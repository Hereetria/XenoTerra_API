using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events.Types
{
    public class BlockUserUpdatedEventType :  ObjectType<BlockUserUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserUpdatedAdminEvent> descriptor)
        {
        }
    }
}

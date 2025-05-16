using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events.Types
{
    public class BlockUserDeletedEventType : ObjectType<BlockUserDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserDeletedSelfEvent> descriptor)
        {
        }
    }
}

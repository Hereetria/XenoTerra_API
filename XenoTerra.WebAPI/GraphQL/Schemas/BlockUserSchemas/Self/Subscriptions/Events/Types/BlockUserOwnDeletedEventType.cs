using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events.Types
{
    public class BlockUserOwnDeletedEventType : ObjectType<BlockUserOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserOwnDeletedEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events.Types
{
    public class BlockUserOwnChangedEventType : ObjectType<BlockUserOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserOwnChangedEvent> descriptor)
        {
        }
    }
}

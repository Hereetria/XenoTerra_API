using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events.Types
{
    public class BlockUserSelfChangedEventType : ObjectType<BlockUserSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserSelfChangedEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events.Types
{
    public class BlockUserSelfDeletedEventType : ObjectType<BlockUserSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserSelfDeletedEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events.Types
{
    public class BlockUserOwnCreatedEventType : ObjectType<BlockUserOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserOwnCreatedEvent> descriptor)
        {
        }
    }
}

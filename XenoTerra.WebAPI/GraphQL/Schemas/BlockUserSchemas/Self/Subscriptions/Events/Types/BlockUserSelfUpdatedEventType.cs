using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events.Types
{
    public class BlockUserSelfUpdatedEventType :  ObjectType<BlockUserSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserSelfUpdatedEvent> descriptor)
        {
        }
    }
}

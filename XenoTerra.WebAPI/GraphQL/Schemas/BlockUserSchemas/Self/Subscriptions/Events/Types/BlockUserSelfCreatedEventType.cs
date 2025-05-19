using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events.Types
{
    public class BlockUserSelfCreatedEventType : ObjectType<BlockUserSelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserSelfCreatedEvent> descriptor)
        {
        }
    }
}

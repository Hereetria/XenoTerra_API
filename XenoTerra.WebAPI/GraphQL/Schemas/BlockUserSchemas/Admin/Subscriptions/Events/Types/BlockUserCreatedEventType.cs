using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events.Types
{
    public class BlockUserCreatedEventType : ObjectType<BlockUserCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserCreatedEvent> descriptor)
        {
        }
    }
}

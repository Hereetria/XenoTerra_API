using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events.Types
{
    public class BlockUserUpdatedEventType :  ObjectType<BlockUserUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserUpdatedSelfEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events.Types
{
    public class BlockUserChangedEventType : ObjectType<BlockUserChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserChangedSelfEvent> descriptor)
        {
        }
    }
}

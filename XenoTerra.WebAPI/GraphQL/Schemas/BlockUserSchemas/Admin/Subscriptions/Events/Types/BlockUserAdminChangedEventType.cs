using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events.Types
{
    public class BlockUserAdminChangedEventType : ObjectType<BlockUserAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserAdminChangedEvent> descriptor)
        {
        }
    }
}

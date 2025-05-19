using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events.Types
{
    public class BlockUserAdminDeletedEventType : ObjectType<BlockUserAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserAdminDeletedEvent> descriptor)
        {
        }
    }
}

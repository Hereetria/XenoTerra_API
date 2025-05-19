using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events.Types
{
    public class BlockUserAdminUpdatedEventType :  ObjectType<BlockUserAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserAdminUpdatedEvent> descriptor)
        {
        }
    }
}

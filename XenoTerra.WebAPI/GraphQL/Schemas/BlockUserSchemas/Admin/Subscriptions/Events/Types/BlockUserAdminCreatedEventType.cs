using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events.Types
{
    public class BlockUserAdminCreatedEventType : ObjectType<BlockUserAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<BlockUserAdminCreatedEvent> descriptor)
        {
        }
    }
}

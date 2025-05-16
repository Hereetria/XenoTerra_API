using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsUpdatedEventType : ObjectType<RecentChatsUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsUpdatedAdminEvent> descriptor)
        {
        }
    }
}
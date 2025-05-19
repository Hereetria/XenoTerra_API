using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsAdminDeletedEventType : ObjectType<RecentChatsAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsAdminDeletedEvent> descriptor)
        {
        }
    }
}
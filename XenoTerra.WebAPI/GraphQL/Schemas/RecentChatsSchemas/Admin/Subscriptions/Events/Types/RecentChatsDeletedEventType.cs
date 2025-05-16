using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsDeletedEventType : ObjectType<RecentChatsDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsDeletedAdminEvent> descriptor)
        {
        }
    }
}
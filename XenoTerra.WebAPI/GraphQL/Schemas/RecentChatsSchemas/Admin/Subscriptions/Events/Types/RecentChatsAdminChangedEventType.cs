using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsAdminChangedEventType : ObjectType<RecentChatsAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsAdminChangedEvent> descriptor)
        {
        }
    }
}
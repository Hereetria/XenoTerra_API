using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsAdminUpdatedEventType : ObjectType<RecentChatsAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsAdminUpdatedEvent> descriptor)
        {
        }
    }
}
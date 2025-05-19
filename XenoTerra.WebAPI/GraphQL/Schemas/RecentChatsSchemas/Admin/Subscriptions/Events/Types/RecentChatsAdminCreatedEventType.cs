using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsAdminCreatedEventType : ObjectType<RecentChatsAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsAdminCreatedEvent> descriptor)
        {
        }
    }
}
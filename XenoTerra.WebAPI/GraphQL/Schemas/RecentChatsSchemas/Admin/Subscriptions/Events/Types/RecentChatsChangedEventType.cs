using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsChangedEventType : ObjectType<RecentChatsChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsChangedAdminEvent> descriptor)
        {
        }
    }
}
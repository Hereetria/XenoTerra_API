using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsCreatedEventType : ObjectType<RecentChatsCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsCreatedAdminEvent> descriptor)
        {
        }
    }
}
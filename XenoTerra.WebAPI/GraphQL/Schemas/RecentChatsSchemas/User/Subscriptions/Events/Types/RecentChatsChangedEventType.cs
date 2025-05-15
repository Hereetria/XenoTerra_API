using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsChangedEventType : ObjectType<RecentChatsChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsChangedEvent> descriptor)
        {
        }
    }
}
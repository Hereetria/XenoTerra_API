using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events.Types
{
    public class RecentChatsSelfChangedEventType : ObjectType<RecentChatsSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsSelfChangedEvent> descriptor)
        {
        }
    }
}
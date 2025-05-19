using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events.Types
{
    public class RecentChatsSelfDeletedEventType : ObjectType<RecentChatsSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsSelfDeletedEvent> descriptor)
        {
        }
    }
}
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events.Types
{
    public class RecentChatsSelfUpdatedEventType : ObjectType<RecentChatsSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsSelfUpdatedEvent> descriptor)
        {
        }
    }
}
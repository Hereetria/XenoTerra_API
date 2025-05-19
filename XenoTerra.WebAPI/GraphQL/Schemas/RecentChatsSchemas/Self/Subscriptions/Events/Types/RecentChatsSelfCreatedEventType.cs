using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events.Types
{
    public class RecentChatsSelfCreatedEventType : ObjectType<RecentChatsSelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsSelfCreatedEvent> descriptor)
        {
        }
    }
}
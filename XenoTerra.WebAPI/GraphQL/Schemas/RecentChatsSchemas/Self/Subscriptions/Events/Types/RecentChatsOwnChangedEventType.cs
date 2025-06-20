using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events.Types
{
    public class RecentChatsOwnChangedEventType : ObjectType<RecentChatsOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsOwnChangedEvent> descriptor)
        {
        }
    }
}
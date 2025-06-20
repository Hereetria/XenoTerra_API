using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events.Types
{
    public class RecentChatsOwnUpdatedEventType : ObjectType<RecentChatsOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsOwnUpdatedEvent> descriptor)
        {
        }
    }
}
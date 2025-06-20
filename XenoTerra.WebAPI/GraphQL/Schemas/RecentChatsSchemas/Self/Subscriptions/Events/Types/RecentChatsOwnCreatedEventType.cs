using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events.Types
{
    public class RecentChatsOwnCreatedEventType : ObjectType<RecentChatsOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsOwnCreatedEvent> descriptor)
        {
        }
    }
}
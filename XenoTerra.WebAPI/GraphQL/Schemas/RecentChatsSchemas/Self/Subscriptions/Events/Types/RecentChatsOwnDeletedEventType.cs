using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events.Types
{
    public class RecentChatsOwnDeletedEventType : ObjectType<RecentChatsOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsOwnDeletedEvent> descriptor)
        {
        }
    }
}
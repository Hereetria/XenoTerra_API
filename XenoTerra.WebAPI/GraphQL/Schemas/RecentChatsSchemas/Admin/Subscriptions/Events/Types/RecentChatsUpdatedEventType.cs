using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsUpdatedEventType : ObjectType<RecentChatsUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsUpdatedEvent> descriptor)
        {
        }
    }
}
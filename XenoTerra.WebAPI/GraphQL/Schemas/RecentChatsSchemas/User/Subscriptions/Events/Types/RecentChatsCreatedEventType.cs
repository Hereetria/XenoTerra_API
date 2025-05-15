using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsCreatedEventType : ObjectType<RecentChatsCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsCreatedEvent> descriptor)
        {
        }
    }
}
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsDeletedEventType : ObjectType<RecentChatsDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsDeletedEvent> descriptor)
        {
        }
    }
}
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsChangedEventType : ObjectType<RecentChatsChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsChangedSelfEvent> descriptor)
        {
        }
    }
}
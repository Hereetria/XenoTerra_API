using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsUpdatedEventType : ObjectType<RecentChatsUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsUpdatedSelfEvent> descriptor)
        {
        }
    }
}
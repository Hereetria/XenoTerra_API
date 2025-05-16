using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events.Types
{
    public class RecentChatsCreatedEventType : ObjectType<RecentChatsCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<RecentChatsCreatedSelfEvent> descriptor)
        {
        }
    }
}
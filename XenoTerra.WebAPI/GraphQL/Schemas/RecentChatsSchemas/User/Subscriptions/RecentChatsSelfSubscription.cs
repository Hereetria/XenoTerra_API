using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class RecentChatsSelfSubscription
    {
        [Subscribe]
        public RecentChatsCreatedSelfEvent OnRecentChatsCreated(
            [EventMessage] RecentChatsCreatedSelfEvent evt) => evt;

        [Subscribe]
        public RecentChatsUpdatedSelfEvent OnRecentChatsUpdated(
            [EventMessage] RecentChatsUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public RecentChatsDeletedSelfEvent OnRecentChatsDeleted(
            [EventMessage] RecentChatsDeletedSelfEvent evt) => evt;

        [Subscribe]
        public RecentChatsChangedSelfEvent OnRecentChatsChanged(
            [EventMessage] RecentChatsChangedSelfEvent evt) => evt;
    }
}

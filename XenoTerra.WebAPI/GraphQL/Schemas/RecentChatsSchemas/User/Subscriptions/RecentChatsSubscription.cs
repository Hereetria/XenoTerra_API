using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class RecentChatsSubscription
    {
        [Subscribe]
        public RecentChatsCreatedEvent OnRecentChatsCreated(
            [EventMessage] RecentChatsCreatedEvent evt) => evt;

        [Subscribe]
        public RecentChatsUpdatedEvent OnRecentChatsUpdated(
            [EventMessage] RecentChatsUpdatedEvent evt) => evt;

        [Subscribe]
        public RecentChatsDeletedEvent OnRecentChatsDeleted(
            [EventMessage] RecentChatsDeletedEvent evt) => evt;

        [Subscribe]
        public RecentChatsChangedEvent OnRecentChatsChanged(
            [EventMessage] RecentChatsChangedEvent evt) => evt;
    }
}

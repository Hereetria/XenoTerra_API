using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class RecentChatsAdminSubscription
    {
        [Subscribe]
        public RecentChatsCreatedAdminEvent OnRecentChatsCreated(
            [EventMessage] RecentChatsCreatedAdminEvent evt) => evt;

        [Subscribe]
        public RecentChatsUpdatedAdminEvent OnRecentChatsUpdated(
            [EventMessage] RecentChatsUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public RecentChatsDeletedAdminEvent OnRecentChatsDeleted(
            [EventMessage] RecentChatsDeletedAdminEvent evt) => evt;

        [Subscribe]
        public RecentChatsChangedAdminEvent OnRecentChatsChanged(
            [EventMessage] RecentChatsChangedAdminEvent evt) => evt;
    }
}

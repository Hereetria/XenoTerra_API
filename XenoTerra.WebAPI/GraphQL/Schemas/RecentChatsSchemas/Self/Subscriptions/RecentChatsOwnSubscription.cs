using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RecentChatsSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class RecentChatsOwnSubscription
    {
        [Subscribe]
        public RecentChatsOwnCreatedEvent OnRecentChatsOwnCreated(
            [EventMessage] RecentChatsOwnCreatedEvent evt) => evt;

        [Subscribe]
        public RecentChatsOwnUpdatedEvent OnRecentChatsOwnUpdated(
            [EventMessage] RecentChatsOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public RecentChatsOwnDeletedEvent OnRecentChatsOwnDeleted(
            [EventMessage] RecentChatsOwnDeletedEvent evt) => evt;

        [Subscribe]
        public RecentChatsOwnChangedEvent OnRecentChatsOwnChanged(
            [EventMessage] RecentChatsOwnChangedEvent evt) => evt;
    }
}

using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.FollowSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class FollowOwnSubscription
    {
        [Subscribe]
        public FollowOwnCreatedEvent OnFollowOwnCreated(
            [EventMessage] FollowOwnCreatedEvent evt) => evt;

        [Subscribe]
        public FollowOwnUpdatedEvent OnFollowOwnUpdated(
            [EventMessage] FollowOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public FollowOwnDeletedEvent OnFollowOwnDeleted(
            [EventMessage] FollowOwnDeletedEvent evt) => evt;

        [Subscribe]
        public FollowOwnChangedEvent OnFollowOwnChanged(
            [EventMessage] FollowOwnChangedEvent evt) => evt;
    }
}

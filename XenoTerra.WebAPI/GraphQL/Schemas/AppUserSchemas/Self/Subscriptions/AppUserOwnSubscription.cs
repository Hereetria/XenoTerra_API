using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class AppUserOwnSubscription
    {
        [Subscribe]
        public UserOwnCreatedEvent OnUserOwnCreated(
            [EventMessage] UserOwnCreatedEvent evt) => evt;

        [Subscribe]
        public UserOwnUpdatedEvent OnUserOwnUpdated(
            [EventMessage] UserOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public UserOwnDeletedEvent OnUserOwnDeleted(
            [EventMessage] UserOwnDeletedEvent evt) => evt;

        [Subscribe]
        public UserOwnChangedEvent OnUserOwnChanged(
            [EventMessage] UserOwnChangedEvent evt) => evt;
    }
}

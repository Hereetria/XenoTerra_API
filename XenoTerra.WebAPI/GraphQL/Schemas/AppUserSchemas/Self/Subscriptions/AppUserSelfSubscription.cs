using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class AppUserSelfSubscription
    {
        [Subscribe]
        public UserSelfCreatedEvent OnUserSelfCreated(
            [EventMessage] UserSelfCreatedEvent evt) => evt;

        [Subscribe]
        public UserSelfUpdatedEvent OnUserSelfUpdated(
            [EventMessage] UserSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public UserSelfDeletedEvent OnUserSelfDeleted(
            [EventMessage] UserSelfDeletedEvent evt) => evt;

        [Subscribe]
        public UserSelfChangedEvent OnUserSelfChanged(
            [EventMessage] UserSelfChangedEvent evt) => evt;
    }
}

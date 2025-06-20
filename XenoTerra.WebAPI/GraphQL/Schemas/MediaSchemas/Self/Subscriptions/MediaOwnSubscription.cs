using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class MediaOwnSubscription
    {
        [Subscribe]
        public MediaOwnCreatedEvent OnMediaOwnCreated(
            [EventMessage] MediaOwnCreatedEvent evt) => evt;

        [Subscribe]
        public MediaOwnUpdatedEvent OnMediaOwnUpdated(
            [EventMessage] MediaOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public MediaOwnDeletedEvent OnMediaOwnDeleted(
            [EventMessage] MediaOwnDeletedEvent evt) => evt;

        [Subscribe]
        public MediaOwnChangedEvent OnMediaOwnChanged(
            [EventMessage] MediaOwnChangedEvent evt) => evt;
    }
}

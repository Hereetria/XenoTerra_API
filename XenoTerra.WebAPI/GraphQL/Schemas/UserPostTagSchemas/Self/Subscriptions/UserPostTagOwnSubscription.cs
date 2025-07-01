using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class UserPostTagOwnSubscription
    {
        [Subscribe]
        public UserPostTagOwnCreatedEvent OnUserPostTagOwnCreated(
            [EventMessage] UserPostTagOwnCreatedEvent evt) => evt;

        [Subscribe]
        public UserPostTagOwnUpdatedEvent OnUserPostTagOwnUpdated(
            [EventMessage] UserPostTagOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public UserPostTagOwnDeletedEvent OnUserPostTagOwnDeleted(
            [EventMessage] UserPostTagOwnDeletedEvent evt) => evt;

        [Subscribe]
        public UserPostTagOwnChangedEvent OnUserPostTagOwnChanged(
            [EventMessage] UserPostTagOwnChangedEvent evt) => evt;
    }
}

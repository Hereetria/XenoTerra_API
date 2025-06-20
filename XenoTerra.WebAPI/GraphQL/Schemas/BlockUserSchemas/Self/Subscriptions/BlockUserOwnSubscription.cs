using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class BlockUserOwnSubscription
    {
        [Subscribe]
        public BlockUserOwnCreatedEvent OnBlockUserOwnCreated(
            [EventMessage] BlockUserOwnCreatedEvent evt) => evt;

        [Subscribe]
        public BlockUserOwnUpdatedEvent OnBlockUserOwnUpdated(
            [EventMessage] BlockUserOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public BlockUserOwnDeletedEvent OnBlockUserOwnDeleted(
            [EventMessage] BlockUserOwnDeletedEvent evt) => evt;

        [Subscribe]
        public BlockUserOwnChangedEvent OnBlockUserOwnChanged(
            [EventMessage] BlockUserOwnChangedEvent evt) => evt;
    }
}

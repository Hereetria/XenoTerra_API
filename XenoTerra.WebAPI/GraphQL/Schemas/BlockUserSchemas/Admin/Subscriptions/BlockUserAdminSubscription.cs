using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class BlockUserAdminSubscription
    {
        [Subscribe]
        public BlockUserAdminCreatedEvent OnBlockUserAdminCreated(
            [EventMessage] BlockUserAdminCreatedEvent evt) => evt;

        [Subscribe]
        public BlockUserAdminUpdatedEvent OnBlockUserAdminUpdated(
            [EventMessage] BlockUserAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public BlockUserAdminDeletedEvent OnBlockUserAdminDeleted(
            [EventMessage] BlockUserAdminDeletedEvent evt) => evt;

        [Subscribe]
        public BlockUserAdminChangedEvent OnBlockUserAdminChanged(
            [EventMessage] BlockUserAdminChangedEvent evt) => evt;
    }
}

using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppRoleSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class AppRoleAdminSubscription
    {
        [Subscribe]
        public RoleAdminCreatedEvent OnRoleAdminCreated(
            [EventMessage] RoleAdminCreatedEvent evt) => evt;

        [Subscribe]
        public RoleAdminUpdatedEvent OnRoleAdminUpdated(
            [EventMessage] RoleAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public RoleAdminDeletedEvent OnRoleAdminDeleted(
            [EventMessage] RoleAdminDeletedEvent evt) => evt;

        [Subscribe]
        public RoleAdminChangedEvent OnRoleAdminChanged(
            [EventMessage] RoleAdminChangedEvent evt) => evt;
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class RoleAdminSubscription
    {
        [Subscribe]
        public RoleCreatedAdminEvent OnRoleCreated(
            [EventMessage] RoleCreatedAdminEvent evt) => evt;

        [Subscribe]
        public RoleUpdatedAdminEvent OnRoleUpdated(
            [EventMessage] RoleUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public RoleDeletedAdminEvent OnRoleDeleted(
            [EventMessage] RoleDeletedAdminEvent evt) => evt;

        [Subscribe]
        public RoleChangedAdminEvent OnRoleChanged(
            [EventMessage] RoleChangedAdminEvent evt) => evt;
    }
}

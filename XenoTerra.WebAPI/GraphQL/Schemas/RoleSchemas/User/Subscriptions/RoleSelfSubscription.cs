using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class RoleSelfSubscription
    {
        [Subscribe]
        public RoleCreatedSelfEvent OnRoleCreated(
            [EventMessage] RoleCreatedSelfEvent evt) => evt;

        [Subscribe]
        public RoleUpdatedSelfEvent OnRoleUpdated(
            [EventMessage] RoleUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public RoleDeletedSelfEvent OnRoleDeleted(
            [EventMessage] RoleDeletedSelfEvent evt) => evt;

        [Subscribe]
        public RoleChangedSelfEvent OnRoleChanged(
            [EventMessage] RoleChangedSelfEvent evt) => evt;
    }
}

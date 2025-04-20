using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class RoleSubscription
    {
        [Subscribe]
        public RoleCreatedEvent OnRoleCreated(
            [EventMessage] RoleCreatedEvent evt) => evt;

        [Subscribe]
        public RoleUpdatedEvent OnRoleUpdated(
            [EventMessage] RoleUpdatedEvent evt) => evt;

        [Subscribe]
        public RoleDeletedEvent OnRoleDeleted(
            [EventMessage] RoleDeletedEvent evt) => evt;

        [Subscribe]
        public RoleChangedEvent OnRoleChanged(
            [EventMessage] RoleChangedEvent evt) => evt;
    }
}

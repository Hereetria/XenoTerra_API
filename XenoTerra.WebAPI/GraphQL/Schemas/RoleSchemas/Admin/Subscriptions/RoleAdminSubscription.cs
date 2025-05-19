using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.RoleSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class RoleAdminSubscription
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

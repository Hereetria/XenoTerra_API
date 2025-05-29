using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class UserAdminSubscription
    {
        [Subscribe]
        public UserAdminCreatedEvent OnUserAdminCreated(
            [EventMessage] UserAdminCreatedEvent evt) => evt;

        [Subscribe]
        public UserAdminUpdatedEvent OnUserAdminUpdated(
            [EventMessage] UserAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public UserAdminDeletedEvent OnUserAdminDeleted(
            [EventMessage] UserAdminDeletedEvent evt) => evt;

        [Subscribe]
        public UserAdminChangedEvent OnUserAdminChanged(
            [EventMessage] UserAdminChangedEvent evt) => evt;
    }
}

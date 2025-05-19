using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class UserPostTagAdminSubscription
    {
        [Subscribe]
        public UserPostTagAdminCreatedEvent OnUserPostTagAdminCreated(
            [EventMessage] UserPostTagAdminCreatedEvent evt) => evt;

        [Subscribe]
        public UserPostTagAdminUpdatedEvent OnUserPostTagAdminUpdated(
            [EventMessage] UserPostTagAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public UserPostTagAdminDeletedEvent OnUserPostTagAdminDeleted(
            [EventMessage] UserPostTagAdminDeletedEvent evt) => evt;

        [Subscribe]
        public UserPostTagAdminChangedEvent OnUserPostTagAdminChanged(
            [EventMessage] UserPostTagAdminChangedEvent evt) => evt;
    }
}

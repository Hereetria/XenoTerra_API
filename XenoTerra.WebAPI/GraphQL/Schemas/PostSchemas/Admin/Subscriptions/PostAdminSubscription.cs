using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class PostAdminSubscription
    {
        [Subscribe]
        public PostAdminCreatedEvent OnPostAdminCreated(
            [EventMessage] PostAdminCreatedEvent evt) => evt;

        [Subscribe]
        public PostAdminUpdatedEvent OnPostAdminUpdated(
            [EventMessage] PostAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public PostAdminDeletedEvent OnPostAdminDeleted(
            [EventMessage] PostAdminDeletedEvent evt) => evt;

        [Subscribe]
        public PostAdminChangedEvent OnPostAdminChanged(
            [EventMessage] PostAdminChangedEvent evt) => evt;
    }
}

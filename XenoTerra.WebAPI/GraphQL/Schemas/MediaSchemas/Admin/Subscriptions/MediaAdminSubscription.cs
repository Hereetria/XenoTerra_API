using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class MediaAdminSubscription
    {
        [Subscribe]
        public MediaAdminCreatedEvent OnMediaAdminCreated(
            [EventMessage] MediaAdminCreatedEvent evt) => evt;

        [Subscribe]
        public MediaAdminUpdatedEvent OnMediaAdminUpdated(
            [EventMessage] MediaAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public MediaAdminDeletedEvent OnMediaAdminDeleted(
            [EventMessage] MediaAdminDeletedEvent evt) => evt;

        [Subscribe]
        public MediaAdminChangedEvent OnMediaAdminChanged(
            [EventMessage] MediaAdminChangedEvent evt) => evt;
    }
}

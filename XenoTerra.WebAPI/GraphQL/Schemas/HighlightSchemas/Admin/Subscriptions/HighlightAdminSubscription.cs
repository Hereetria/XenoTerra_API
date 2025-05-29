using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class HighlightAdminSubscription
    {
        [Subscribe]
        public HighlightAdminCreatedEvent OnHighlightAdminCreated(
            [EventMessage] HighlightAdminCreatedEvent evt) => evt;

        [Subscribe]
        public HighlightAdminUpdatedEvent OnHighlightAdminUpdated(
            [EventMessage] HighlightAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public HighlightAdminDeletedEvent OnHighlightAdminDeleted(
            [EventMessage] HighlightAdminDeletedEvent evt) => evt;

        [Subscribe]
        public HighlightAdminChangedEvent OnHighlightAdminChanged(
            [EventMessage] HighlightAdminChangedEvent evt) => evt;
    }
}

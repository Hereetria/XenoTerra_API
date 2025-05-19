using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class ReactionAdminSubscription
    {
        [Subscribe]
        public ReactionAdminCreatedEvent OnReactionAdminCreated(
            [EventMessage] ReactionAdminCreatedEvent evt) => evt;

        [Subscribe]
        public ReactionAdminUpdatedEvent OnReactionAdminUpdated(
            [EventMessage] ReactionAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public ReactionAdminDeletedEvent OnReactionAdminDeleted(
            [EventMessage] ReactionAdminDeletedEvent evt) => evt;

        [Subscribe]
        public ReactionAdminChangedEvent OnReactionAdminChanged(
            [EventMessage] ReactionAdminChangedEvent evt) => evt;
    }
}

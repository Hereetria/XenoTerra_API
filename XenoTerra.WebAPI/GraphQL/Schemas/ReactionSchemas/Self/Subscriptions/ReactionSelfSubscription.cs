using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReactionSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReactionSelfSubscription
    {
        [Subscribe]
        public ReactionSelfCreatedEvent OnReactionSelfCreated(
            [EventMessage] ReactionSelfCreatedEvent evt) => evt;

        [Subscribe]
        public ReactionSelfUpdatedEvent OnReactionSelfUpdated(
            [EventMessage] ReactionSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public ReactionSelfDeletedEvent OnReactionSelfDeleted(
            [EventMessage] ReactionSelfDeletedEvent evt) => evt;

        [Subscribe]
        public ReactionSelfChangedEvent OnReactionSelfChanged(
            [EventMessage] ReactionSelfChangedEvent evt) => evt;
    }
}

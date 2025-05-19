using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.LikeSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class LikeSelfSubscription
    {
        [Subscribe]
        public LikeSelfCreatedEvent OnLikeSelfCreated(
            [EventMessage] LikeSelfCreatedEvent evt) => evt;

        [Subscribe]
        public LikeSelfUpdatedEvent OnLikeSelfUpdated(
            [EventMessage] LikeSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public LikeSelfDeletedEvent OnLikeSelfDeleted(
            [EventMessage] LikeSelfDeletedEvent evt) => evt;

        [Subscribe]
        public LikeSelfChangedEvent OnLikeSelfChanged(
            [EventMessage] LikeSelfChangedEvent evt) => evt;
    }
}

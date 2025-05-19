using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class UserSelfSubscription
    {
        [Subscribe]
        public UserSelfCreatedEvent OnUserSelfCreated(
            [EventMessage] UserSelfCreatedEvent evt) => evt;

        [Subscribe]
        public UserSelfUpdatedEvent OnUserSelfUpdated(
            [EventMessage] UserSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public UserSelfDeletedEvent OnUserSelfDeleted(
            [EventMessage] UserSelfDeletedEvent evt) => evt;

        [Subscribe]
        public UserSelfChangedEvent OnUserSelfChanged(
            [EventMessage] UserSelfChangedEvent evt) => evt;
    }
}

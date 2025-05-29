using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.DTOLayer.Dtos.BlockUserDtos;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.BlockUserSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class BlockUserSelfSubscription
    {
        [Subscribe]
        public BlockUserSelfCreatedEvent OnBlockUserSelfCreated(
            [EventMessage] BlockUserSelfCreatedEvent evt) => evt;

        [Subscribe]
        public BlockUserSelfUpdatedEvent OnBlockUserSelfUpdated(
            [EventMessage] BlockUserSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public BlockUserSelfDeletedEvent OnBlockUserSelfDeleted(
            [EventMessage] BlockUserSelfDeletedEvent evt) => evt;

        [Subscribe]
        public BlockUserSelfChangedEvent OnBlockUserSelfChanged(
            [EventMessage] BlockUserSelfChangedEvent evt) => evt;
    }
}

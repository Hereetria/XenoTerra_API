using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class MediaSelfSubscription
    {
        [Subscribe]
        public MediaSelfCreatedEvent OnMediaSelfCreated(
            [EventMessage] MediaSelfCreatedEvent evt) => evt;

        [Subscribe]
        public MediaSelfUpdatedEvent OnMediaSelfUpdated(
            [EventMessage] MediaSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public MediaSelfDeletedEvent OnMediaSelfDeleted(
            [EventMessage] MediaSelfDeletedEvent evt) => evt;

        [Subscribe]
        public MediaSelfChangedEvent OnMediaSelfChanged(
            [EventMessage] MediaSelfChangedEvent evt) => evt;
    }
}

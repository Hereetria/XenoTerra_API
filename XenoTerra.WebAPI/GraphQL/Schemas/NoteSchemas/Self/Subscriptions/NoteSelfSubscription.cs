using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class NoteSelfSubscription
    {
        [Subscribe]
        public NoteSelfCreatedEvent OnNoteSelfCreated(
            [EventMessage] NoteSelfCreatedEvent evt) => evt;

        [Subscribe]
        public NoteSelfUpdatedEvent OnNoteSelfUpdated(
            [EventMessage] NoteSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public NoteSelfDeletedEvent OnNoteSelfDeleted(
            [EventMessage] NoteSelfDeletedEvent evt) => evt;

        [Subscribe]
        public NoteSelfChangedEvent OnNoteSelfChanged(
            [EventMessage] NoteSelfChangedEvent evt) => evt;
    }
}

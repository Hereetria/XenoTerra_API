using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class StorySelfSubscription
    {
        [Subscribe]
        public StorySelfCreatedEvent OnStorySelfCreated(
            [EventMessage] StorySelfCreatedEvent evt) => evt;

        [Subscribe]
        public StorySelfUpdatedEvent OnStorySelfUpdated(
            [EventMessage] StorySelfUpdatedEvent evt) => evt;

        [Subscribe]
        public StorySelfDeletedEvent OnStorySelfDeleted(
            [EventMessage] StorySelfDeletedEvent evt) => evt;

        [Subscribe]
        public StorySelfChangedEvent OnStorySelfChanged(
            [EventMessage] StorySelfChangedEvent evt) => evt;
    }
}

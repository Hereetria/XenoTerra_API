using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class SavedPostSelfSubscription
    {
        [Subscribe]
        public SavedPostSelfCreatedEvent OnSavedPostSelfCreated(
            [EventMessage] SavedPostSelfCreatedEvent evt) => evt;

        [Subscribe]
        public SavedPostSelfUpdatedEvent OnSavedPostSelfUpdated(
            [EventMessage] SavedPostSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public SavedPostSelfDeletedEvent OnSavedPostSelfDeleted(
            [EventMessage] SavedPostSelfDeletedEvent evt) => evt;

        [Subscribe]
        public SavedPostSelfChangedEvent OnSavedPostSelfChanged(
            [EventMessage] SavedPostSelfChangedEvent evt) => evt;
    }
}

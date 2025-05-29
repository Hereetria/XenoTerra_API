using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class SavedPostAdminSubscription
    {
        [Subscribe]
        public SavedPostAdminCreatedEvent OnSavedPostAdminCreated(
            [EventMessage] SavedPostAdminCreatedEvent evt) => evt;

        [Subscribe]
        public SavedPostAdminUpdatedEvent OnSavedPostAdminUpdated(
            [EventMessage] SavedPostAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public SavedPostAdminDeletedEvent OnSavedPostAdminDeleted(
            [EventMessage] SavedPostAdminDeletedEvent evt) => evt;

        [Subscribe]
        public SavedPostAdminChangedEvent OnSavedPostAdminChanged(
            [EventMessage] SavedPostAdminChangedEvent evt) => evt;
    }
}

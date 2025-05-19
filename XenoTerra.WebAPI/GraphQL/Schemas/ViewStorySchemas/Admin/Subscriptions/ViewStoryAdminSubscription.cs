using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class ViewStoryAdminSubscription
    {
        [Subscribe]
        public ViewStoryAdminCreatedEvent OnViewStoryAdminCreated(
            [EventMessage] ViewStoryAdminCreatedEvent evt) => evt;

        [Subscribe]
        public ViewStoryAdminUpdatedEvent OnViewStoryAdminUpdated(
            [EventMessage] ViewStoryAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public ViewStoryAdminDeletedEvent OnViewStoryAdminDeleted(
            [EventMessage] ViewStoryAdminDeletedEvent evt) => evt;

        [Subscribe]
        public ViewStoryAdminChangedEvent OnViewStoryAdminChanged(
            [EventMessage] ViewStoryAdminChangedEvent evt) => evt;
    }
}

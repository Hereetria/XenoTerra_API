using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class StoryAdminSubscription
    {
        [Subscribe]
        public StoryAdminCreatedEvent OnStoryAdminCreated(
            [EventMessage] StoryAdminCreatedEvent evt) => evt;

        [Subscribe]
        public StoryAdminUpdatedEvent OnStoryAdminUpdated(
            [EventMessage] StoryAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public StoryAdminDeletedEvent OnStoryAdminDeleted(
            [EventMessage] StoryAdminDeletedEvent evt) => evt;

        [Subscribe]
        public StoryAdminChangedEvent OnStoryAdminChanged(
            [EventMessage] StoryAdminChangedEvent evt) => evt;
    }
}

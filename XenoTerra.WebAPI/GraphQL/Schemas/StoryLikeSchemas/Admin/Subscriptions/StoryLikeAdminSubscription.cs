using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class StoryLikeAdminSubscription
    {
        [Subscribe]
        public StoryLikeAdminCreatedEvent OnStoryLikeAdminCreated(
            [EventMessage] StoryLikeAdminCreatedEvent evt) => evt;

        [Subscribe]
        public StoryLikeAdminUpdatedEvent OnStoryLikeAdminUpdated(
            [EventMessage] StoryLikeAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public StoryLikeAdminDeletedEvent OnStoryLikeAdminDeleted(
            [EventMessage] StoryLikeAdminDeletedEvent evt) => evt;

        [Subscribe]
        public StoryLikeAdminChangedEvent OnStoryLikeAdminChanged(
            [EventMessage] StoryLikeAdminChangedEvent evt) => evt;
    }
}

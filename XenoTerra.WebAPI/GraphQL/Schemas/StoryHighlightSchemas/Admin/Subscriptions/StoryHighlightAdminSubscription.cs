using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class StoryHighlightAdminSubscription
    {
        [Subscribe]
        public StoryHighlightAdminCreatedEvent OnStoryHighlightAdminCreated(
            [EventMessage] StoryHighlightAdminCreatedEvent evt) => evt;

        [Subscribe]
        public StoryHighlightAdminUpdatedEvent OnStoryHighlightAdminUpdated(
            [EventMessage] StoryHighlightAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public StoryHighlightAdminDeletedEvent OnStoryHighlightAdminDeleted(
            [EventMessage] StoryHighlightAdminDeletedEvent evt) => evt;

        [Subscribe]
        public StoryHighlightAdminChangedEvent OnStoryHighlightAdminChanged(
            [EventMessage] StoryHighlightAdminChangedEvent evt) => evt;
    }
}

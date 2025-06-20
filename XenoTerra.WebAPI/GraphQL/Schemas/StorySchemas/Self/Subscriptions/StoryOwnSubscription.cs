using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class StoryOwnSubscription
    {
        [Subscribe]
        public StoryOwnCreatedEvent OnStoryOwnCreated(
            [EventMessage] StoryOwnCreatedEvent evt) => evt;

        [Subscribe]
        public StoryOwnUpdatedEvent OnStoryOwnUpdated(
            [EventMessage] StoryOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public StoryOwnDeletedEvent OnStoryOwnDeleted(
            [EventMessage] StoryOwnDeletedEvent evt) => evt;

        [Subscribe]
        public StoryOwnChangedEvent OnStoryOwnChanged(
            [EventMessage] StoryOwnChangedEvent evt) => evt;
    }
}

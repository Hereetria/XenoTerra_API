using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryLikeSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class StoryLikeOwnSubscription
    {
        [Subscribe]
        public StoryLikeOwnCreatedEvent OnLikeOwnCreated(
            [EventMessage] StoryLikeOwnCreatedEvent evt) => evt;

        [Subscribe]
        public StoryLikeOwnUpdatedEvent OnLikeOwnUpdated(
            [EventMessage] StoryLikeOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public StoryLikeOwnDeletedEvent OnLikeOwnDeleted(
            [EventMessage] StoryLikeOwnDeletedEvent evt) => evt;

        [Subscribe]
        public StoryLikeOwnChangedEvent OnLikeOwnChanged(
            [EventMessage] StoryLikeOwnChangedEvent evt) => evt;
    }
}

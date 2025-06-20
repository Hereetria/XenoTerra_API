using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class PostLikeOwnSubscription
    {
        [Subscribe]
        public PostLikeOwnCreatedEvent OnPostLikeOwnCreated(
            [EventMessage] PostLikeOwnCreatedEvent evt) => evt;

        [Subscribe]
        public PostLikeOwnUpdatedEvent OnPostLikeOwnUpdated(
            [EventMessage] PostLikeOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public PostLikeOwnDeletedEvent OnPostLikeOwnDeleted(
            [EventMessage] PostLikeOwnDeletedEvent evt) => evt;

        [Subscribe]
        public PostLikeOwnChangedEvent OnPostLikeOwnChanged(
            [EventMessage] PostLikeOwnChangedEvent evt) => evt;
    }
}

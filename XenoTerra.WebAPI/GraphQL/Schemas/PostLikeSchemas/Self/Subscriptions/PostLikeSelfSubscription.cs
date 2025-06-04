using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostLikeSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class PostLikeSelfSubscription
    {
        [Subscribe]
        public PostLikeSelfCreatedEvent OnLikeSelfCreated(
            [EventMessage] PostLikeSelfCreatedEvent evt) => evt;

        [Subscribe]
        public PostLikeSelfUpdatedEvent OnLikeSelfUpdated(
            [EventMessage] PostLikeSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public PostLikeSelfDeletedEvent OnLikeSelfDeleted(
            [EventMessage] PostLikeSelfDeletedEvent evt) => evt;

        [Subscribe]
        public PostLikeSelfChangedEvent OnLikeSelfChanged(
            [EventMessage] PostLikeSelfChangedEvent evt) => evt;
    }
}

using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ViewStoryOwnSubscription
    {
        [Subscribe]
        public ViewStoryOwnCreatedEvent OnViewStoryOwnCreated(
            [EventMessage] ViewStoryOwnCreatedEvent evt) => evt;

        [Subscribe]
        public ViewStoryOwnUpdatedEvent OnViewStoryOwnUpdated(
            [EventMessage] ViewStoryOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public ViewStoryOwnDeletedEvent OnViewStoryOwnDeleted(
            [EventMessage] ViewStoryOwnDeletedEvent evt) => evt;

        [Subscribe]
        public ViewStoryOwnChangedEvent OnViewStoryOwnChanged(
            [EventMessage] ViewStoryOwnChangedEvent evt) => evt;
    }
}

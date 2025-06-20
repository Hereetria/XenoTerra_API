using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class PostOwnSubscription
    {
        [Subscribe]
        public PostOwnCreatedEvent OnPostOwnCreated(
            [EventMessage] PostOwnCreatedEvent evt) => evt;

        [Subscribe]
        public PostOwnUpdatedEvent OnPostOwnUpdated(
            [EventMessage] PostOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public PostOwnDeletedEvent OnPostOwnDeleted(
            [EventMessage] PostOwnDeletedEvent evt) => evt;

        [Subscribe]
        public PostOwnChangedEvent OnPostOwnChanged(
            [EventMessage] PostOwnChangedEvent evt) => evt;
    }
}

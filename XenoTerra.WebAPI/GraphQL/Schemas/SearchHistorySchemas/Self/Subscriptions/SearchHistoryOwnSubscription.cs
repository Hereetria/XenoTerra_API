using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class SearchHistoryOwnSubscription
    {
        [Subscribe]
        public SearchHistoryOwnCreatedEvent OnSearchHistoryOwnCreated(
            [EventMessage] SearchHistoryOwnCreatedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryOwnUpdatedEvent OnSearchHistoryOwnUpdated(
            [EventMessage] SearchHistoryOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryOwnDeletedEvent OnSearchHistoryOwnDeleted(
            [EventMessage] SearchHistoryOwnDeletedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryOwnChangedEvent OnSearchHistoryOwnChanged(
            [EventMessage] SearchHistoryOwnChangedEvent evt) => evt;
    }
}

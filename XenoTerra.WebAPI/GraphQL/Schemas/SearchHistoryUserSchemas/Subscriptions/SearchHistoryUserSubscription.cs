using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class SearchHistoryUserSubscription
    {
        [Subscribe]
        public SearchHistoryUserCreatedEvent OnSearchHistoryUserCreated(
            [EventMessage] SearchHistoryUserCreatedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUserUpdatedEvent OnSearchHistoryUserUpdated(
            [EventMessage] SearchHistoryUserUpdatedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUserDeletedEvent OnSearchHistoryUserDeleted(
            [EventMessage] SearchHistoryUserDeletedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUserChangedEvent OnSearchHistoryUserChanged(
            [EventMessage] SearchHistoryUserChangedEvent evt) => evt;
    }
}

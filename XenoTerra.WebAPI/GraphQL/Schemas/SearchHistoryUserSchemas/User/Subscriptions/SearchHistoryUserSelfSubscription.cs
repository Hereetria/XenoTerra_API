using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class SearchHistoryUserSelfSubscription
    {
        [Subscribe]
        public SearchHistoryUserCreatedSelfEvent OnSearchHistoryUserCreated(
            [EventMessage] SearchHistoryUserCreatedSelfEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUserUpdatedSelfEvent OnSearchHistoryUserUpdated(
            [EventMessage] SearchHistoryUserUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUserDeletedSelfEvent OnSearchHistoryUserDeleted(
            [EventMessage] SearchHistoryUserDeletedSelfEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUserChangedSelfEvent OnSearchHistoryUserChanged(
            [EventMessage] SearchHistoryUserChangedSelfEvent evt) => evt;
    }
}

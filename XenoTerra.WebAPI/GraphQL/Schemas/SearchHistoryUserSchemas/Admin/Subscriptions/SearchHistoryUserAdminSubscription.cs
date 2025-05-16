using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class SearchHistoryUserAdminSubscription
    {
        [Subscribe]
        public SearchHistoryUserCreatedAdminEvent OnSearchHistoryUserCreated(
            [EventMessage] SearchHistoryUserCreatedAdminEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUserUpdatedAdminEvent OnSearchHistoryUserUpdated(
            [EventMessage] SearchHistoryUserUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUserDeletedAdminEvent OnSearchHistoryUserDeleted(
            [EventMessage] SearchHistoryUserDeletedAdminEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUserChangedAdminEvent OnSearchHistoryUserChanged(
            [EventMessage] SearchHistoryUserChangedAdminEvent evt) => evt;
    }
}

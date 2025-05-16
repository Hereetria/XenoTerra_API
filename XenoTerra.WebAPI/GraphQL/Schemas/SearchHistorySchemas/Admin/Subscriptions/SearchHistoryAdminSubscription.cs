using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class SearchHistoryAdminSubscription
    {
        [Subscribe]
        public SearchHistoryCreatedAdminEvent OnSearchHistoryCreated(
            [EventMessage] SearchHistoryCreatedAdminEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUpdatedAdminEvent OnSearchHistoryUpdated(
            [EventMessage] SearchHistoryUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public SearchHistoryDeletedAdminEvent OnSearchHistoryDeleted(
            [EventMessage] SearchHistoryDeletedAdminEvent evt) => evt;

        [Subscribe]
        public SearchHistoryChangedAdminEvent OnSearchHistoryChanged(
            [EventMessage] SearchHistoryChangedAdminEvent evt) => evt;
    }
}

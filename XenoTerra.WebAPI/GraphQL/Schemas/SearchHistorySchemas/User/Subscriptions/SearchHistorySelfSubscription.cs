using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class SearchHistorySelfSubscription
    {
        [Subscribe]
        public SearchHistoryCreatedSelfEvent OnSearchHistoryCreated(
            [EventMessage] SearchHistoryCreatedSelfEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUpdatedSelfEvent OnSearchHistoryUpdated(
            [EventMessage] SearchHistoryUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public SearchHistoryDeletedSelfEvent OnSearchHistoryDeleted(
            [EventMessage] SearchHistoryDeletedSelfEvent evt) => evt;

        [Subscribe]
        public SearchHistoryChangedSelfEvent OnSearchHistoryChanged(
            [EventMessage] SearchHistoryChangedSelfEvent evt) => evt;
    }
}

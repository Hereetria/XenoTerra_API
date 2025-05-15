using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class SearchHistorySubscription
    {
        [Subscribe]
        public SearchHistoryCreatedEvent OnSearchHistoryCreated(
            [EventMessage] SearchHistoryCreatedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryUpdatedEvent OnSearchHistoryUpdated(
            [EventMessage] SearchHistoryUpdatedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryDeletedEvent OnSearchHistoryDeleted(
            [EventMessage] SearchHistoryDeletedEvent evt) => evt;

        [Subscribe]
        public SearchHistoryChangedEvent OnSearchHistoryChanged(
            [EventMessage] SearchHistoryChangedEvent evt) => evt;
    }
}

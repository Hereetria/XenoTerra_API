using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events.Types
{
    public class SearchHistorySelfUpdatedEventType : ObjectType<SearchHistorySelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistorySelfUpdatedEvent> descriptor)
        {
        }
    }
}
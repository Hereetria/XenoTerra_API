using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events.Types
{
    public class SearchHistorySelfChangedEventType : ObjectType<SearchHistorySelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistorySelfChangedEvent> descriptor)
        {
        }
    }
}
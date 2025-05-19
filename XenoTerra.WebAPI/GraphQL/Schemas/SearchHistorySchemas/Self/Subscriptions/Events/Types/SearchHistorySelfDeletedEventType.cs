using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events.Types
{
    public class SearchHistorySelfDeletedEventType : ObjectType<SearchHistorySelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistorySelfDeletedEvent> descriptor)
        {
        }
    }
}
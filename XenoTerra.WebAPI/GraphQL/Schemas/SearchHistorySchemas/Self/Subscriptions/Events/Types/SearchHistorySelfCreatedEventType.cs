using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events.Types
{
    public class SearchHistorySelfCreatedEventType : ObjectType<SearchHistorySelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistorySelfCreatedEvent> descriptor)
        {
        }
    }
}
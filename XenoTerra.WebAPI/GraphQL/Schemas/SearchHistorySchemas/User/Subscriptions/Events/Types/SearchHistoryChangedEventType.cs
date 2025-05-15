using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryChangedEventType : ObjectType<SearchHistoryChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryChangedEvent> descriptor)
        {
        }
    }
}
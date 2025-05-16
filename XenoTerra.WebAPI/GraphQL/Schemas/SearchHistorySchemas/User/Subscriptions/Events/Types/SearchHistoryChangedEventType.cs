using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryChangedEventType : ObjectType<SearchHistoryChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryChangedSelfEvent> descriptor)
        {
        }
    }
}
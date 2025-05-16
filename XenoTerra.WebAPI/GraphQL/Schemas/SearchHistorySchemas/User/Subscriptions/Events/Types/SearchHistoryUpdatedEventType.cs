using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUpdatedEventType : ObjectType<SearchHistoryUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUpdatedSelfEvent> descriptor)
        {
        }
    }
}
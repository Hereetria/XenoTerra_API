using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryCreatedEventType : ObjectType<SearchHistoryCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryCreatedSelfEvent> descriptor)
        {
        }
    }
}
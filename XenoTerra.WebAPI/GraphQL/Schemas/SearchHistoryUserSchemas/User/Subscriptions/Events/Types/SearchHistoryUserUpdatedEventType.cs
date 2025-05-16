using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUserUpdatedEventType : ObjectType<SearchHistoryUserUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserUpdatedSelfEvent> descriptor)
        {
        }
    }
}
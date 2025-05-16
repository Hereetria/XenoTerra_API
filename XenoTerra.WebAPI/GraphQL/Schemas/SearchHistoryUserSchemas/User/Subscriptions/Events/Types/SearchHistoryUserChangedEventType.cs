using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUserChangedEventType : ObjectType<SearchHistoryUserChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserChangedSelfEvent> descriptor)
        {
        }
    }
}
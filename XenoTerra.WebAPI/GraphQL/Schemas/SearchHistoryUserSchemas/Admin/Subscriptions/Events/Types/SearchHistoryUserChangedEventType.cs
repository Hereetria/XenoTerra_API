using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUserChangedEventType : ObjectType<SearchHistoryUserChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserChangedAdminEvent> descriptor)
        {
        }
    }
}
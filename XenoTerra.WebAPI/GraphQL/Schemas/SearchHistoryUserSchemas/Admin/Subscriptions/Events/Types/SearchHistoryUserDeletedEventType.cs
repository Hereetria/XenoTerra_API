using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUserDeletedEventType : ObjectType<SearchHistoryUserDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserDeletedAdminEvent> descriptor)
        {
        }
    }
}
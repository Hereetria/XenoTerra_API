using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUserDeletedEventType : ObjectType<SearchHistoryUserDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserDeletedEvent> descriptor)
        {
        }
    }
}
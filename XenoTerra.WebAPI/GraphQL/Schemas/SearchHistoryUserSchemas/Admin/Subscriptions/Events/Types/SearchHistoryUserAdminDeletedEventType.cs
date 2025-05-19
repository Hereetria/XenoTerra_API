using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUserAdminDeletedEventType : ObjectType<SearchHistoryUserAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserAdminDeletedEvent> descriptor)
        {
        }
    }
}
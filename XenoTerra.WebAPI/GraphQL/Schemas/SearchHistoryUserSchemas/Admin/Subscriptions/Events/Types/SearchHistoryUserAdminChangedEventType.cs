using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUserAdminChangedEventType : ObjectType<SearchHistoryUserAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserAdminChangedEvent> descriptor)
        {
        }
    }
}
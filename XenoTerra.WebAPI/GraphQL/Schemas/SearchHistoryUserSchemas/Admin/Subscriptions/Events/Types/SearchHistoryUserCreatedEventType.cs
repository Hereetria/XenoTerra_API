using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUserCreatedEventType : ObjectType<SearchHistoryUserCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserCreatedAdminEvent> descriptor)
        {
        }
    }
}
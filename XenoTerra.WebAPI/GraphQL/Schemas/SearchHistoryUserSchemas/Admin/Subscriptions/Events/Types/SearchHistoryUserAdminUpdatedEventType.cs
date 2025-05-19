using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUserAdminUpdatedEventType : ObjectType<SearchHistoryUserAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserAdminUpdatedEvent> descriptor)
        {
        }
    }
}
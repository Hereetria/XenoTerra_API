using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUserAdminCreatedEventType : ObjectType<SearchHistoryUserAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserAdminCreatedEvent> descriptor)
        {
        }
    }
}
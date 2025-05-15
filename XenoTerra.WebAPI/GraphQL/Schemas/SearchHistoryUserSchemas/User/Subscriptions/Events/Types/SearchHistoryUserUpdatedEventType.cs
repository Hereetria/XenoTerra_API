using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUserUpdatedEventType : ObjectType<SearchHistoryUserUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserUpdatedEvent> descriptor)
        {
        }
    }
}
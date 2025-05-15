using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUserCreatedEventType : ObjectType<SearchHistoryUserCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserCreatedEvent> descriptor)
        {
        }
    }
}
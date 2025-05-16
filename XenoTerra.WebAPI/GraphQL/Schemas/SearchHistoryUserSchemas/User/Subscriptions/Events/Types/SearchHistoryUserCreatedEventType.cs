using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistoryUserSchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUserCreatedEventType : ObjectType<SearchHistoryUserCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUserCreatedSelfEvent> descriptor)
        {
        }
    }
}
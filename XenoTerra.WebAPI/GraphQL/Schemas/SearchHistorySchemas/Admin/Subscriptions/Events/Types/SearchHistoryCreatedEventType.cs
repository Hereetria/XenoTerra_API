using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryCreatedEventType : ObjectType<SearchHistoryCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryCreatedEvent> descriptor)
        {
        }
    }
}
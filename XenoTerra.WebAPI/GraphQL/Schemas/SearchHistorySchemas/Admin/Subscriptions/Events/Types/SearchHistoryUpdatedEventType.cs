using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUpdatedEventType : ObjectType<SearchHistoryUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUpdatedEvent> descriptor)
        {
        }
    }
}
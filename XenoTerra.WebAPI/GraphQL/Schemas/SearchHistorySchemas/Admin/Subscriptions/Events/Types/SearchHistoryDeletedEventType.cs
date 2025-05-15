using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryDeletedEventType : ObjectType<SearchHistoryDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryDeletedEvent> descriptor)
        {
        }
    }
}
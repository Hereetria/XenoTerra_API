using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryDeletedEventType : ObjectType<SearchHistoryDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryDeletedSelfEvent> descriptor)
        {
        }
    }
}
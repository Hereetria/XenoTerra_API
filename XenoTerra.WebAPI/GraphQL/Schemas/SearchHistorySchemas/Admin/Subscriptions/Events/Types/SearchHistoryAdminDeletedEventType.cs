using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryAdminDeletedEventType : ObjectType<SearchHistoryAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryAdminDeletedEvent> descriptor)
        {
        }
    }
}
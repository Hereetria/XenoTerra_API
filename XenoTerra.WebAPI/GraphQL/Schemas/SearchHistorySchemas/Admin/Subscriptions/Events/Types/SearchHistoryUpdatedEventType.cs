using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryUpdatedEventType : ObjectType<SearchHistoryUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryUpdatedAdminEvent> descriptor)
        {
        }
    }
}
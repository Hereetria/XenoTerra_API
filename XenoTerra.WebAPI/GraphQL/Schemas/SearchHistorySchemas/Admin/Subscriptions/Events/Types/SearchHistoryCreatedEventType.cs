using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryCreatedEventType : ObjectType<SearchHistoryCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryCreatedAdminEvent> descriptor)
        {
        }
    }
}
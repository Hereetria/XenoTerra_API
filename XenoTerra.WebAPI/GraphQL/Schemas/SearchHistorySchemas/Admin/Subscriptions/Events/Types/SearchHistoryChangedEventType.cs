using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryChangedEventType : ObjectType<SearchHistoryChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryChangedAdminEvent> descriptor)
        {
        }
    }
}
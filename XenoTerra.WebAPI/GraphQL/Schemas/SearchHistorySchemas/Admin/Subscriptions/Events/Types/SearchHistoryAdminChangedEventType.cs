using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryAdminChangedEventType : ObjectType<SearchHistoryAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryAdminChangedEvent> descriptor)
        {
        }
    }
}
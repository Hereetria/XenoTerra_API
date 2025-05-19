using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryAdminUpdatedEventType : ObjectType<SearchHistoryAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryAdminUpdatedEvent> descriptor)
        {
        }
    }
}
using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Admin.Subscriptions.Events.Types
{
    public class SearchHistoryAdminCreatedEventType : ObjectType<SearchHistoryAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryAdminCreatedEvent> descriptor)
        {
        }
    }
}
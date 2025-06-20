using XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SearchHistorySchemas.Self.Subscriptions.Events.Types
{
    public class SearchHistoryOwnDeletedEventType : ObjectType<SearchHistoryOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<SearchHistoryOwnDeletedEvent> descriptor)
        {
        }
    }
}
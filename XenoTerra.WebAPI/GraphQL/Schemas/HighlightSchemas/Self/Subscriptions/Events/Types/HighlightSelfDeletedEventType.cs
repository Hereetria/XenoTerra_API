using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events.Types
{
    public class HighlightSelfDeletedEventType : ObjectType<HighlightSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightSelfDeletedEvent> descriptor)
        {
        }
    }
}

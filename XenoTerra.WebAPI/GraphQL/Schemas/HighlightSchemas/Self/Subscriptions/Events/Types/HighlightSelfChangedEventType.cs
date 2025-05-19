using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events.Types
{
    public class HighlightSelfChangedEventType : ObjectType<HighlightSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightSelfChangedEvent> descriptor)
        {
        }
    }
}

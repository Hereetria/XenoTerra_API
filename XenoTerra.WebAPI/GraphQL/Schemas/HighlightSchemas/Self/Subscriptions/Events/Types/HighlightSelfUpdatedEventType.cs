using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events.Types
{
    public class HighlightSelfUpdatedEventType : ObjectType<HighlightSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightSelfUpdatedEvent> descriptor)
        {
        }
    }
}

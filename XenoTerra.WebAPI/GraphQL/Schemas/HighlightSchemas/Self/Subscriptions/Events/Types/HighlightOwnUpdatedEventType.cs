using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events.Types
{
    public class HighlightOwnUpdatedEventType : ObjectType<HighlightOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightOwnUpdatedEvent> descriptor)
        {
        }
    }
}

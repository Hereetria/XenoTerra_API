using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events.Types
{
    public class HighlightSelfCreatedEventType : ObjectType<HighlightSelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightSelfCreatedEvent> descriptor)
        {
        }
    }
}

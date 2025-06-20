using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Self.Subscriptions.Events.Types
{
    public class HighlightOwnDeletedEventType : ObjectType<HighlightOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightOwnDeletedEvent> descriptor)
        {
        }
    }
}

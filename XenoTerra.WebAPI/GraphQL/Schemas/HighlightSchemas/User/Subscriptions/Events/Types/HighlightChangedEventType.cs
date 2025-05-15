using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class HighlightChangedEventType : ObjectType<HighlightChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightChangedEvent> descriptor)
        {
        }
    }
}

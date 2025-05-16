using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class HighlightCreatedEventType : ObjectType<HighlightCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightCreatedSelfEvent> descriptor)
        {
        }
    }
}

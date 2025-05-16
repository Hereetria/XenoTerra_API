using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class HighlightUpdatedEventType : ObjectType<HighlightUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightUpdatedSelfEvent> descriptor)
        {
        }
    }
}

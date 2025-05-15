using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class HighlightCreatedEventType : ObjectType<HighlightCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightCreatedEvent> descriptor)
        {
        }
    }
}

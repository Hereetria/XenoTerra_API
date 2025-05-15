using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class HighlightDeletedEventType : ObjectType<HighlightDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightDeletedEvent> descriptor)
        {
        }
    }
}

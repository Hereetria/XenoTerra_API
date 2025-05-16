using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class HighlightChangedEventType : ObjectType<HighlightChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightChangedAdminEvent> descriptor)
        {
        }
    }
}

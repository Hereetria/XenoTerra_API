using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class HighlightAdminChangedEventType : ObjectType<HighlightAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightAdminChangedEvent> descriptor)
        {
        }
    }
}

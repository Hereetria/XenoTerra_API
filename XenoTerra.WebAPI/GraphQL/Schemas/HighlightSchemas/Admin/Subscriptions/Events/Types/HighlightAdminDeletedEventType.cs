using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class HighlightAdminDeletedEventType : ObjectType<HighlightAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightAdminDeletedEvent> descriptor)
        {
        }
    }
}

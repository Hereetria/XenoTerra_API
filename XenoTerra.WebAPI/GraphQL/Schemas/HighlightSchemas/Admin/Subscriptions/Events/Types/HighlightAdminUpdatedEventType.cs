using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class HighlightAdminUpdatedEventType : ObjectType<HighlightAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightAdminUpdatedEvent> descriptor)
        {
        }
    }
}

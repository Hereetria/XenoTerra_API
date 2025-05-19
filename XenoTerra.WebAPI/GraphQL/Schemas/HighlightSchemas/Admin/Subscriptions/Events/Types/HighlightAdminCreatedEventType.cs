using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class HighlightAdminCreatedEventType : ObjectType<HighlightAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightAdminCreatedEvent> descriptor)
        {
        }
    }
}

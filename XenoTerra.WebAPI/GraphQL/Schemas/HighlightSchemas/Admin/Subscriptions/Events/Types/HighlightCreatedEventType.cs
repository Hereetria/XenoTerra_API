using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class HighlightCreatedEventType : ObjectType<HighlightCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightCreatedAdminEvent> descriptor)
        {
        }
    }
}

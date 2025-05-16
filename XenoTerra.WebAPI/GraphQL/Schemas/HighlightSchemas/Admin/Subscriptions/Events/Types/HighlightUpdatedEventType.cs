using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events.Types
{
    public class HighlightUpdatedEventType : ObjectType<HighlightUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<HighlightUpdatedAdminEvent> descriptor)
        {
        }
    }
}

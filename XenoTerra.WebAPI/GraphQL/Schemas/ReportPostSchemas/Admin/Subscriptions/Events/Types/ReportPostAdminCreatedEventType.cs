using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportPostAdminCreatedEventType : ObjectType<ReportPostAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportPostAdminCreatedEvent> descriptor)
        {
        }
    }
}
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportPostAdminUpdatedEventType : ObjectType<ReportPostAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportPostAdminUpdatedEvent> descriptor)
        {
        }
    }
}
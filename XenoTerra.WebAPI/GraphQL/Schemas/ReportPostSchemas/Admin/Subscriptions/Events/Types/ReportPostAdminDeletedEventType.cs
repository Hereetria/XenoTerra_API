using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportPostAdminDeletedEventType : ObjectType<ReportPostAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportPostAdminDeletedEvent> descriptor)
        {
        }
    }
}
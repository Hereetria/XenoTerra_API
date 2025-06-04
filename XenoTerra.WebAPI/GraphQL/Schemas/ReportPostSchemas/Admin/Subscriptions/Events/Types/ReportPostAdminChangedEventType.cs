using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportPostAdminChangedEventType : ObjectType<ReportPostAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportPostAdminChangedEvent> descriptor)
        {
        }
    }
}
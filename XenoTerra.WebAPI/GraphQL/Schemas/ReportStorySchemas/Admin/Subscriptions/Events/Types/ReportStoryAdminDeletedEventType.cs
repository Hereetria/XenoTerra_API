using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Subscriptions.Events.Types
{
    public class ReportStoryAdminDeletedEventType : ObjectType<ReportStoryAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportStoryAdminDeletedEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Subscriptions.Events.Types
{
    public class ReportStoryAdminUpdatedEventType : ObjectType<ReportStoryAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportStoryAdminUpdatedEvent> descriptor)
        {
        }
    }
}

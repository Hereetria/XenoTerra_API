using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Subscriptions.Events.Types
{
    public class ReportStoryAdminCreatedEventType : ObjectType<ReportStoryAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportStoryAdminCreatedEvent> descriptor)
        {
        }
    }
}

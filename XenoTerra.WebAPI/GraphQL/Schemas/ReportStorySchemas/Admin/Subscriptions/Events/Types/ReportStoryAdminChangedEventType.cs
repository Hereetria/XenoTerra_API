using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Subscriptions.Events.Types
{
    public class ReportStoryAdminChangedEventType : ObjectType<ReportStoryAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportStoryAdminChangedEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportCommentAdminUpdatedEventType : ObjectType<ReportCommentAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentAdminUpdatedEvent> descriptor)
        {
        }
    }
}
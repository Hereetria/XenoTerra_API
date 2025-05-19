using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportCommentAdminDeletedEventType : ObjectType<ReportCommentAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentAdminDeletedEvent> descriptor)
        {
        }
    }
}
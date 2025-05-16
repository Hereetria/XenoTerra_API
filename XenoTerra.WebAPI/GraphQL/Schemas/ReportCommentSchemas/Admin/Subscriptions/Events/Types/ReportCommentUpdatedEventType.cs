using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportCommentUpdatedEventType : ObjectType<ReportCommentUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentUpdatedAdminEvent> descriptor)
        {
        }
    }
}
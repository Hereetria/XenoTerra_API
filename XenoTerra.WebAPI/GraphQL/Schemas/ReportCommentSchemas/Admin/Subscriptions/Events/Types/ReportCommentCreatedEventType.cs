using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportCommentCreatedEventType : ObjectType<ReportCommentCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentCreatedAdminEvent> descriptor)
        {
        }
    }
}
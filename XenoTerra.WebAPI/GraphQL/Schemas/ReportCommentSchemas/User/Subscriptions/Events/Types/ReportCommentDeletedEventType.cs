using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportCommentDeletedEventType : ObjectType<ReportCommentDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentDeletedEvent> descriptor)
        {
        }
    }
}
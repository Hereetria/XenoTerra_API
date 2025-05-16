using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportCommentCreatedEventType : ObjectType<ReportCommentCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentCreatedSelfEvent> descriptor)
        {
        }
    }
}
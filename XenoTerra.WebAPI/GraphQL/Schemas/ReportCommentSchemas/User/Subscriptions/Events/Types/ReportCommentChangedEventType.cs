using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportCommentChangedEventType : ObjectType<ReportCommentChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentChangedSelfEvent> descriptor)
        {
        }
    }
}
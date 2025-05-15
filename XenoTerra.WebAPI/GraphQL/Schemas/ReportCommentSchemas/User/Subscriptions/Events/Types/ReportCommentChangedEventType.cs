using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportCommentChangedEventType : ObjectType<ReportCommentChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentChangedEvent> descriptor)
        {
        }
    }
}
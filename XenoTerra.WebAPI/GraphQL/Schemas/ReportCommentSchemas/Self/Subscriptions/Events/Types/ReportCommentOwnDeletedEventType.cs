using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events.Types
{
    public class ReportCommentOwnDeletedEventType : ObjectType<ReportCommentOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentOwnDeletedEvent> descriptor)
        {
        }
    }
}
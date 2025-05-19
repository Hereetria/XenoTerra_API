using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events.Types
{
    public class ReportCommentSelfChangedEventType : ObjectType<ReportCommentSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentSelfChangedEvent> descriptor)
        {
        }
    }
}
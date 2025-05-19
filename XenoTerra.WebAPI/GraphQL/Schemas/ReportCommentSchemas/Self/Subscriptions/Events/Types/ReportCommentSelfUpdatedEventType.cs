using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events.Types
{
    public class ReportCommentSelfUpdatedEventType : ObjectType<ReportCommentSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentSelfUpdatedEvent> descriptor)
        {
        }
    }
}
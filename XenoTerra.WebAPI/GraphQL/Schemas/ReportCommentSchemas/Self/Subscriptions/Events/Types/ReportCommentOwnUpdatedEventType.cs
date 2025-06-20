using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events.Types
{
    public class ReportCommentOwnUpdatedEventType : ObjectType<ReportCommentOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentOwnUpdatedEvent> descriptor)
        {
        }
    }
}
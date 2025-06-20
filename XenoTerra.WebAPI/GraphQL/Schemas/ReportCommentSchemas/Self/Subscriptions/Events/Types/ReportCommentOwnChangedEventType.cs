using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events.Types
{
    public class ReportCommentOwnChangedEventType : ObjectType<ReportCommentOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentOwnChangedEvent> descriptor)
        {
        }
    }
}
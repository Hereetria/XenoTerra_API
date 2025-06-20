using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events.Types
{
    public class ReportCommentOwnCreatedEventType : ObjectType<ReportCommentOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentOwnCreatedEvent> descriptor)
        {
        }
    }
}
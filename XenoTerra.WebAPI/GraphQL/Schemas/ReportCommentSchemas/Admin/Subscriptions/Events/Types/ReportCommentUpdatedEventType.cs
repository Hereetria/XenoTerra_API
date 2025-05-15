using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportCommentUpdatedEventType : ObjectType<ReportCommentUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentUpdatedEvent> descriptor)
        {
        }
    }
}
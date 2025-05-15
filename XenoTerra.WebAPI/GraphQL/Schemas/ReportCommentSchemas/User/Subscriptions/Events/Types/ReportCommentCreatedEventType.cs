using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportCommentCreatedEventType : ObjectType<ReportCommentCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentCreatedEvent> descriptor)
        {
        }
    }
}
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportCommentAdminCreatedEventType : ObjectType<ReportCommentAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentAdminCreatedEvent> descriptor)
        {
        }
    }
}
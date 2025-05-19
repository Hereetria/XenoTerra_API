using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportCommentAdminChangedEventType : ObjectType<ReportCommentAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentAdminChangedEvent> descriptor)
        {
        }
    }
}
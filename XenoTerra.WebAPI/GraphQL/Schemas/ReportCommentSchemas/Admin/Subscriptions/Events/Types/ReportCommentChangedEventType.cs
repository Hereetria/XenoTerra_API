using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events.Types
{
    public class ReportCommentChangedEventType : ObjectType<ReportCommentChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<ReportCommentChangedAdminEvent> descriptor)
        {
        }
    }
}
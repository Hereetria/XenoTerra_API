using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class ReportCommentAdminSubscription
    {
        [Subscribe]
        public ReportCommentCreatedAdminEvent OnReportCommentCreated(
            [EventMessage] ReportCommentCreatedAdminEvent evt) => evt;

        [Subscribe]
        public ReportCommentUpdatedAdminEvent OnReportCommentUpdated(
            [EventMessage] ReportCommentUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public ReportCommentDeletedAdminEvent OnReportCommentDeleted(
            [EventMessage] ReportCommentDeletedAdminEvent evt) => evt;

        [Subscribe]
        public ReportCommentChangedAdminEvent OnReportCommentChanged(
            [EventMessage] ReportCommentChangedAdminEvent evt) => evt;
    }
}

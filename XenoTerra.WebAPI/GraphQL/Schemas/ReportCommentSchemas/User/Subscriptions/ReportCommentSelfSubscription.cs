using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class ReportCommentSelfSubscription
    {
        [Subscribe]
        public ReportCommentCreatedSelfEvent OnReportCommentCreated(
            [EventMessage] ReportCommentCreatedSelfEvent evt) => evt;

        [Subscribe]
        public ReportCommentUpdatedSelfEvent OnReportCommentUpdated(
            [EventMessage] ReportCommentUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public ReportCommentDeletedSelfEvent OnReportCommentDeleted(
            [EventMessage] ReportCommentDeletedSelfEvent evt) => evt;

        [Subscribe]
        public ReportCommentChangedSelfEvent OnReportCommentChanged(
            [EventMessage] ReportCommentChangedSelfEvent evt) => evt;
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class ReportCommentSubscription
    {
        [Subscribe]
        public ReportCommentCreatedEvent OnReportCommentCreated(
            [EventMessage] ReportCommentCreatedEvent evt) => evt;

        [Subscribe]
        public ReportCommentUpdatedEvent OnReportCommentUpdated(
            [EventMessage] ReportCommentUpdatedEvent evt) => evt;

        [Subscribe]
        public ReportCommentDeletedEvent OnReportCommentDeleted(
            [EventMessage] ReportCommentDeletedEvent evt) => evt;

        [Subscribe]
        public ReportCommentChangedEvent OnReportCommentChanged(
            [EventMessage] ReportCommentChangedEvent evt) => evt;
    }
}

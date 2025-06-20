using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReportCommentOwnSubscription
    {
        [Subscribe]
        public ReportCommentOwnCreatedEvent OnReportCommentOwnCreated(
            [EventMessage] ReportCommentOwnCreatedEvent evt) => evt;

        [Subscribe]
        public ReportCommentOwnUpdatedEvent OnReportCommentOwnUpdated(
            [EventMessage] ReportCommentOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public ReportCommentOwnDeletedEvent OnReportCommentOwnDeleted(
            [EventMessage] ReportCommentOwnDeletedEvent evt) => evt;

        [Subscribe]
        public ReportCommentOwnChangedEvent OnReportCommentOwnChanged(
            [EventMessage] ReportCommentOwnChangedEvent evt) => evt;
    }
}

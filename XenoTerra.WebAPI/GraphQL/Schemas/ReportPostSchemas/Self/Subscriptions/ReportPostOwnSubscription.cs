using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReportPostOwnSubscription
    {
        [Subscribe]
        public ReportPostOwnCreatedEvent OnReportPostOwnCreated(
            [EventMessage] ReportPostOwnCreatedEvent evt) => evt;

        [Subscribe]
        public ReportPostOwnUpdatedEvent OnReportPostOwnUpdated(
            [EventMessage] ReportPostOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public ReportPostOwnDeletedEvent OnReportPostOwnDeleted(
            [EventMessage] ReportPostOwnDeletedEvent evt) => evt;

        [Subscribe]
        public ReportPostOwnChangedEvent OnReportPostOwnChanged(
            [EventMessage] ReportPostOwnChangedEvent evt) => evt;
    }
}

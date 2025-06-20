using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReportStoryOwnSubscription
    {
        [Subscribe]
        public ReportStoryOwnCreatedEvent OnReportStoryOwnCreated(
            [EventMessage] ReportStoryOwnCreatedEvent evt) => evt;

        [Subscribe]
        public ReportStoryOwnUpdatedEvent OnReportStoryOwnUpdated(
            [EventMessage] ReportStoryOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public ReportStoryOwnDeletedEvent OnReportStoryOwnDeleted(
            [EventMessage] ReportStoryOwnDeletedEvent evt) => evt;

        [Subscribe]
        public ReportStoryOwnChangedEvent OnReportStoryOwnChanged(
            [EventMessage] ReportStoryOwnChangedEvent evt) => evt;
    }
}

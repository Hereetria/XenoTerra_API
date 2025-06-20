using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportStorySchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class ReportStoryAdminSubscription
    {
        [Subscribe]
        public ReportStoryAdminCreatedEvent OnReportStoryAdminCreated(
            [EventMessage] ReportStoryAdminCreatedEvent evt) => evt;

        [Subscribe]
        public ReportStoryAdminUpdatedEvent OnReportStoryAdminUpdated(
            [EventMessage] ReportStoryAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public ReportStoryAdminDeletedEvent OnReportStoryAdminDeleted(
            [EventMessage] ReportStoryAdminDeletedEvent evt) => evt;

        [Subscribe]
        public ReportStoryAdminChangedEvent OnReportStoryAdminChanged(
            [EventMessage] ReportStoryAdminChangedEvent evt) => evt;
    }
}

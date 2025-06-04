using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.Admin) })]
    public class ReportPostAdminSubscription
    {
        [Subscribe]
        public ReportPostAdminCreatedEvent OnReportPostAdminCreated(
            [EventMessage] ReportPostAdminCreatedEvent evt) => evt;

        [Subscribe]
        public ReportPostAdminUpdatedEvent OnReportPostAdminUpdated(
            [EventMessage] ReportPostAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public ReportPostAdminDeletedEvent OnReportPostAdminDeleted(
            [EventMessage] ReportPostAdminDeletedEvent evt) => evt;

        [Subscribe]
        public ReportPostAdminChangedEvent OnReportPostAdminChanged(
            [EventMessage] ReportPostAdminChangedEvent evt) => evt;
    }
}

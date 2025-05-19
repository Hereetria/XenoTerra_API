using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class ReportCommentAdminSubscription
    {
        [Subscribe]
        public ReportCommentAdminCreatedEvent OnReportCommentAdminCreated(
            [EventMessage] ReportCommentAdminCreatedEvent evt) => evt;

        [Subscribe]
        public ReportCommentAdminUpdatedEvent OnReportCommentAdminUpdated(
            [EventMessage] ReportCommentAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public ReportCommentAdminDeletedEvent OnReportCommentAdminDeleted(
            [EventMessage] ReportCommentAdminDeletedEvent evt) => evt;

        [Subscribe]
        public ReportCommentAdminChangedEvent OnReportCommentAdminChanged(
            [EventMessage] ReportCommentAdminChangedEvent evt) => evt;
    }
}

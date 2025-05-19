using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportCommentSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.User), nameof(Roles.Admin) })]
    public class ReportCommentSelfSubscription
    {
        [Subscribe]
        public ReportCommentSelfCreatedEvent OnReportCommentSelfCreated(
            [EventMessage] ReportCommentSelfCreatedEvent evt) => evt;

        [Subscribe]
        public ReportCommentSelfUpdatedEvent OnReportCommentSelfUpdated(
            [EventMessage] ReportCommentSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public ReportCommentSelfDeletedEvent OnReportCommentSelfDeleted(
            [EventMessage] ReportCommentSelfDeletedEvent evt) => evt;

        [Subscribe]
        public ReportCommentSelfChangedEvent OnReportCommentSelfChanged(
            [EventMessage] ReportCommentSelfChangedEvent evt) => evt;
    }
}

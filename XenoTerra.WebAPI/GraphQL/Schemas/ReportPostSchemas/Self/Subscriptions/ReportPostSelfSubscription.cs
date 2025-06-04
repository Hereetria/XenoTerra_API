using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ReportPostSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class ReportPostSelfSubscription
    {
        [Subscribe]
        public ReportPostSelfCreatedEvent OnReportPostSelfCreated(
            [EventMessage] ReportPostSelfCreatedEvent evt) => evt;

        [Subscribe]
        public ReportPostSelfUpdatedEvent OnReportPostSelfUpdated(
            [EventMessage] ReportPostSelfUpdatedEvent evt) => evt;

        [Subscribe]
        public ReportPostSelfDeletedEvent OnReportPostSelfDeleted(
            [EventMessage] ReportPostSelfDeletedEvent evt) => evt;

        [Subscribe]
        public ReportPostSelfChangedEvent OnReportPostSelfChanged(
            [EventMessage] ReportPostSelfChangedEvent evt) => evt;
    }
}

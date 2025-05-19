using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
﻿using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(Roles.Admin) })]
    public class NoteAdminSubscription
    {
        [Subscribe]
        public NoteAdminCreatedEvent OnNoteAdminCreated(
            [EventMessage] NoteAdminCreatedEvent evt) => evt;

        [Subscribe]
        public NoteAdminUpdatedEvent OnNoteAdminUpdated(
            [EventMessage] NoteAdminUpdatedEvent evt) => evt;

        [Subscribe]
        public NoteAdminDeletedEvent OnNoteAdminDeleted(
            [EventMessage] NoteAdminDeletedEvent evt) => evt;

        [Subscribe]
        public NoteAdminChangedEvent OnNoteAdminChanged(
            [EventMessage] NoteAdminChangedEvent evt) => evt;
    }
}

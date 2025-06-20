using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class NoteOwnSubscription
    {
        [Subscribe]
        public NoteOwnCreatedEvent OnNoteOwnCreated(
            [EventMessage] NoteOwnCreatedEvent evt) => evt;

        [Subscribe]
        public NoteOwnUpdatedEvent OnNoteOwnUpdated(
            [EventMessage] NoteOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public NoteOwnDeletedEvent OnNoteOwnDeleted(
            [EventMessage] NoteOwnDeletedEvent evt) => evt;

        [Subscribe]
        public NoteOwnChangedEvent OnNoteOwnChanged(
            [EventMessage] NoteOwnChangedEvent evt) => evt;
    }
}

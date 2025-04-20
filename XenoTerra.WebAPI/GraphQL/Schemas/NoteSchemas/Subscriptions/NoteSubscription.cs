using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class NoteSubscription
    {
        [Subscribe]
        public NoteCreatedEvent OnNoteCreated(
            [EventMessage] NoteCreatedEvent evt) => evt;

        [Subscribe]
        public NoteUpdatedEvent OnNoteUpdated(
            [EventMessage] NoteUpdatedEvent evt) => evt;

        [Subscribe]
        public NoteDeletedEvent OnNoteDeleted(
            [EventMessage] NoteDeletedEvent evt) => evt;

        [Subscribe]
        public NoteChangedEvent OnNoteChanged(
            [EventMessage] NoteChangedEvent evt) => evt;
    }
}

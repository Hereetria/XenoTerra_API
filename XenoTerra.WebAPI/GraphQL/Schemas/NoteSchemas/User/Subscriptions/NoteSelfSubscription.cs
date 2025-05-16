using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class NoteSelfSubscription
    {
        [Subscribe]
        public NoteCreatedSelfEvent OnNoteCreated(
            [EventMessage] NoteCreatedSelfEvent evt) => evt;

        [Subscribe]
        public NoteUpdatedSelfEvent OnNoteUpdated(
            [EventMessage] NoteUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public NoteDeletedSelfEvent OnNoteDeleted(
            [EventMessage] NoteDeletedSelfEvent evt) => evt;

        [Subscribe]
        public NoteChangedSelfEvent OnNoteChanged(
            [EventMessage] NoteChangedSelfEvent evt) => evt;
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.NoteSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class NoteAdminSubscription
    {
        [Subscribe]
        public NoteCreatedAdminEvent OnNoteCreated(
            [EventMessage] NoteCreatedAdminEvent evt) => evt;

        [Subscribe]
        public NoteUpdatedAdminEvent OnNoteUpdated(
            [EventMessage] NoteUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public NoteDeletedAdminEvent OnNoteDeleted(
            [EventMessage] NoteDeletedAdminEvent evt) => evt;

        [Subscribe]
        public NoteChangedAdminEvent OnNoteChanged(
            [EventMessage] NoteChangedAdminEvent evt) => evt;
    }
}

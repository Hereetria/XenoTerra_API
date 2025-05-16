using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class SavedPostSelfSubscription
    {
        [Subscribe]
        public SavedPostCreatedSelfEvent OnSavedPostCreated(
            [EventMessage] SavedPostCreatedSelfEvent evt) => evt;

        [Subscribe]
        public SavedPostUpdatedSelfEvent OnSavedPostUpdated(
            [EventMessage] SavedPostUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public SavedPostDeletedSelfEvent OnSavedPostDeleted(
            [EventMessage] SavedPostDeletedSelfEvent evt) => evt;

        [Subscribe]
        public SavedPostChangedSelfEvent OnSavedPostChanged(
            [EventMessage] SavedPostChangedSelfEvent evt) => evt;
    }
}

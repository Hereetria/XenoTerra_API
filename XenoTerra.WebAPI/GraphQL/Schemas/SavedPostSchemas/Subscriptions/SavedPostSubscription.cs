using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class SavedPostSubscription
    {
        [Subscribe]
        public SavedPostCreatedEvent OnSavedPostCreated(
            [EventMessage] SavedPostCreatedEvent evt) => evt;

        [Subscribe]
        public SavedPostUpdatedEvent OnSavedPostUpdated(
            [EventMessage] SavedPostUpdatedEvent evt) => evt;

        [Subscribe]
        public SavedPostDeletedEvent OnSavedPostDeleted(
            [EventMessage] SavedPostDeletedEvent evt) => evt;

        [Subscribe]
        public SavedPostChangedEvent OnSavedPostChanged(
            [EventMessage] SavedPostChangedEvent evt) => evt;
    }
}

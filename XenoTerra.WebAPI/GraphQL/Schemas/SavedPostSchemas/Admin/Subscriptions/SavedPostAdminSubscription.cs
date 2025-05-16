using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class SavedPostAdminSubscription
    {
        [Subscribe]
        public SavedPostCreatedAdminEvent OnSavedPostCreated(
            [EventMessage] SavedPostCreatedAdminEvent evt) => evt;

        [Subscribe]
        public SavedPostUpdatedAdminEvent OnSavedPostUpdated(
            [EventMessage] SavedPostUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public SavedPostDeletedAdminEvent OnSavedPostDeleted(
            [EventMessage] SavedPostDeletedAdminEvent evt) => evt;

        [Subscribe]
        public SavedPostChangedAdminEvent OnSavedPostChanged(
            [EventMessage] SavedPostChangedAdminEvent evt) => evt;
    }
}

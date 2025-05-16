using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class ViewStoryAdminSubscription
    {
        [Subscribe]
        public ViewStoryCreatedAdminEvent OnViewStoryCreated(
            [EventMessage] ViewStoryCreatedAdminEvent evt) => evt;

        [Subscribe]
        public ViewStoryUpdatedAdminEvent OnViewStoryUpdated(
            [EventMessage] ViewStoryUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public ViewStoryDeletedAdminEvent OnViewStoryDeleted(
            [EventMessage] ViewStoryDeletedAdminEvent evt) => evt;

        [Subscribe]
        public ViewStoryChangedAdminEvent OnViewStoryChanged(
            [EventMessage] ViewStoryChangedAdminEvent evt) => evt;
    }
}

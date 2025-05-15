using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class ViewStorySubscription
    {
        [Subscribe]
        public ViewStoryCreatedEvent OnViewStoryCreated(
            [EventMessage] ViewStoryCreatedEvent evt) => evt;

        [Subscribe]
        public ViewStoryUpdatedEvent OnViewStoryUpdated(
            [EventMessage] ViewStoryUpdatedEvent evt) => evt;

        [Subscribe]
        public ViewStoryDeletedEvent OnViewStoryDeleted(
            [EventMessage] ViewStoryDeletedEvent evt) => evt;

        [Subscribe]
        public ViewStoryChangedEvent OnViewStoryChanged(
            [EventMessage] ViewStoryChangedEvent evt) => evt;
    }
}

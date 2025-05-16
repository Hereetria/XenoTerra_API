using XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.ViewStorySchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class ViewStorySelfSubscription
    {
        [Subscribe]
        public ViewStoryCreatedSelfEvent OnViewStoryCreated(
            [EventMessage] ViewStoryCreatedSelfEvent evt) => evt;

        [Subscribe]
        public ViewStoryUpdatedSelfEvent OnViewStoryUpdated(
            [EventMessage] ViewStoryUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public ViewStoryDeletedSelfEvent OnViewStoryDeleted(
            [EventMessage] ViewStoryDeletedSelfEvent evt) => evt;

        [Subscribe]
        public ViewStoryChangedSelfEvent OnViewStoryChanged(
            [EventMessage] ViewStoryChangedSelfEvent evt) => evt;
    }
}

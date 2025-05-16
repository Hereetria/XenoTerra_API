using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class StoryAdminSubscription
    {
        [Subscribe]
        public StoryCreatedAdminEvent OnStoryCreated(
            [EventMessage] StoryCreatedAdminEvent evt) => evt;

        [Subscribe]
        public StoryUpdatedAdminEvent OnStoryUpdated(
            [EventMessage] StoryUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public StoryDeletedAdminEvent OnStoryDeleted(
            [EventMessage] StoryDeletedAdminEvent evt) => evt;

        [Subscribe]
        public StoryChangedAdminEvent OnStoryChanged(
            [EventMessage] StoryChangedAdminEvent evt) => evt;
    }
}

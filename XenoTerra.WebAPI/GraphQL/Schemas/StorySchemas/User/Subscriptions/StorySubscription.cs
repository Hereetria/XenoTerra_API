using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class StorySubscription
    {
        [Subscribe]
        public StoryCreatedEvent OnStoryCreated(
            [EventMessage] StoryCreatedEvent evt) => evt;

        [Subscribe]
        public StoryUpdatedEvent OnStoryUpdated(
            [EventMessage] StoryUpdatedEvent evt) => evt;

        [Subscribe]
        public StoryDeletedEvent OnStoryDeleted(
            [EventMessage] StoryDeletedEvent evt) => evt;

        [Subscribe]
        public StoryChangedEvent OnStoryChanged(
            [EventMessage] StoryChangedEvent evt) => evt;
    }
}

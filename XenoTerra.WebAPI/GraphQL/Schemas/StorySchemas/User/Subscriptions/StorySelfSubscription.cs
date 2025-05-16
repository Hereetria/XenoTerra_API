using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class StorySelfSubscription
    {
        [Subscribe]
        public StoryCreatedSelfEvent OnStoryCreated(
            [EventMessage] StoryCreatedSelfEvent evt) => evt;

        [Subscribe]
        public StoryUpdatedSelfEvent OnStoryUpdated(
            [EventMessage] StoryUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public StoryDeletedSelfEvent OnStoryDeleted(
            [EventMessage] StoryDeletedSelfEvent evt) => evt;

        [Subscribe]
        public StoryChangedSelfEvent OnStoryChanged(
            [EventMessage] StoryChangedSelfEvent evt) => evt;
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class StoryHighlightSubscription
    {
        [Subscribe]
        public StoryHighlightCreatedEvent OnStoryHighlightCreated(
            [EventMessage] StoryHighlightCreatedEvent evt) => evt;

        [Subscribe]
        public StoryHighlightUpdatedEvent OnStoryHighlightUpdated(
            [EventMessage] StoryHighlightUpdatedEvent evt) => evt;

        [Subscribe]
        public StoryHighlightDeletedEvent OnStoryHighlightDeleted(
            [EventMessage] StoryHighlightDeletedEvent evt) => evt;

        [Subscribe]
        public StoryHighlightChangedEvent OnStoryHighlightChanged(
            [EventMessage] StoryHighlightChangedEvent evt) => evt;
    }
}

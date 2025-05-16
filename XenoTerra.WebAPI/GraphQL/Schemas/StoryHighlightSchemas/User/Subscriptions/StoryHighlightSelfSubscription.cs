using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class StoryHighlightSelfSubscription
    {
        [Subscribe]
        public StoryHighlightCreatedSelfEvent OnStoryHighlightCreated(
            [EventMessage] StoryHighlightCreatedSelfEvent evt) => evt;

        [Subscribe]
        public StoryHighlightUpdatedSelfEvent OnStoryHighlightUpdated(
            [EventMessage] StoryHighlightUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public StoryHighlightDeletedSelfEvent OnStoryHighlightDeleted(
            [EventMessage] StoryHighlightDeletedSelfEvent evt) => evt;

        [Subscribe]
        public StoryHighlightChangedSelfEvent OnStoryHighlightChanged(
            [EventMessage] StoryHighlightChangedSelfEvent evt) => evt;
    }
}

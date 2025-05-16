using XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions.Events;
using XenoTerra.WebAPI.GraphQL.Schemas.StorySchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.StoryHighlightSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class StoryHighlightAdminSubscription
    {
        [Subscribe]
        public StoryHighlightCreatedAdminEvent OnStoryHighlightCreated(
            [EventMessage] StoryHighlightCreatedAdminEvent evt) => evt;

        [Subscribe]
        public StoryHighlightUpdatedAdminEvent OnStoryHighlightUpdated(
            [EventMessage] StoryHighlightUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public StoryHighlightDeletedAdminEvent OnStoryHighlightDeleted(
            [EventMessage] StoryHighlightDeletedAdminEvent evt) => evt;

        [Subscribe]
        public StoryHighlightChangedAdminEvent OnStoryHighlightChanged(
            [EventMessage] StoryHighlightChangedAdminEvent evt) => evt;
    }
}

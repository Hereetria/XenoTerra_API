using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class HighlightSelfSubscription
    {
        [Subscribe]
        public HighlightCreatedSelfEvent OnHighlightCreated(
            [EventMessage] HighlightCreatedSelfEvent evt) => evt;

        [Subscribe]
        public HighlightUpdatedSelfEvent OnHighlightUpdated(
            [EventMessage] HighlightUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public HighlightDeletedSelfEvent OnHighlightDeleted(
            [EventMessage] HighlightDeletedSelfEvent evt) => evt;

        [Subscribe]
        public HighlightChangedSelfEvent OnHighlightChanged(
            [EventMessage] HighlightChangedSelfEvent evt) => evt;
    }
}

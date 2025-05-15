using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class HighlightSubscription
    {
        [Subscribe]
        public HighlightCreatedEvent OnHighlightCreated(
            [EventMessage] HighlightCreatedEvent evt) => evt;

        [Subscribe]
        public HighlightUpdatedEvent OnHighlightUpdated(
            [EventMessage] HighlightUpdatedEvent evt) => evt;

        [Subscribe]
        public HighlightDeletedEvent OnHighlightDeleted(
            [EventMessage] HighlightDeletedEvent evt) => evt;

        [Subscribe]
        public HighlightChangedEvent OnHighlightChanged(
            [EventMessage] HighlightChangedEvent evt) => evt;
    }
}

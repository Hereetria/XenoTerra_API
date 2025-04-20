using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class MediaSubscription
    {
        [Subscribe]
        public MediaCreatedEvent OnMediaCreated(
            [EventMessage] MediaCreatedEvent evt) => evt;

        [Subscribe]
        public MediaUpdatedEvent OnMediaUpdated(
            [EventMessage] MediaUpdatedEvent evt) => evt;

        [Subscribe]
        public MediaDeletedEvent OnMediaDeleted(
            [EventMessage] MediaDeletedEvent evt) => evt;

        [Subscribe]
        public MediaChangedEvent OnMediaChanged(
            [EventMessage] MediaChangedEvent evt) => evt;
    }
}

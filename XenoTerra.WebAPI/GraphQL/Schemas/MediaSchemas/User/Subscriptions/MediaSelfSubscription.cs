using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class MediaSelfSubscription
    {
        [Subscribe]
        public MediaCreatedSelfEvent OnMediaCreated(
            [EventMessage] MediaCreatedSelfEvent evt) => evt;

        [Subscribe]
        public MediaUpdatedSelfEvent OnMediaUpdated(
            [EventMessage] MediaUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public MediaDeletedSelfEvent OnMediaDeleted(
            [EventMessage] MediaDeletedSelfEvent evt) => evt;

        [Subscribe]
        public MediaChangedSelfEvent OnMediaChanged(
            [EventMessage] MediaChangedSelfEvent evt) => evt;
    }
}

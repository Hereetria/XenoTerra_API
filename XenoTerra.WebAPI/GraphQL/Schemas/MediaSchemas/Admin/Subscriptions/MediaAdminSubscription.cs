using XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.MediaSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class MediaAdminSubscription
    {
        [Subscribe]
        public MediaCreatedAdminEvent OnMediaCreated(
            [EventMessage] MediaCreatedAdminEvent evt) => evt;

        [Subscribe]
        public MediaUpdatedAdminEvent OnMediaUpdated(
            [EventMessage] MediaUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public MediaDeletedAdminEvent OnMediaDeleted(
            [EventMessage] MediaDeletedAdminEvent evt) => evt;

        [Subscribe]
        public MediaChangedAdminEvent OnMediaChanged(
            [EventMessage] MediaChangedAdminEvent evt) => evt;
    }
}

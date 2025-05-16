using XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.HighlightSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class HighlightAdminSubscription
    {
        [Subscribe]
        public HighlightCreatedAdminEvent OnHighlightCreated(
            [EventMessage] HighlightCreatedAdminEvent evt) => evt;

        [Subscribe]
        public HighlightUpdatedAdminEvent OnHighlightUpdated(
            [EventMessage] HighlightUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public HighlightDeletedAdminEvent OnHighlightDeleted(
            [EventMessage] HighlightDeletedAdminEvent evt) => evt;

        [Subscribe]
        public HighlightChangedAdminEvent OnHighlightChanged(
            [EventMessage] HighlightChangedAdminEvent evt) => evt;
    }
}

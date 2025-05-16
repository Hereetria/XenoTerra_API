using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class PostAdminSubscription
    {
        [Subscribe]
        public PostCreatedAdminEvent OnPostCreated(
            [EventMessage] PostCreatedAdminEvent evt) => evt;

        [Subscribe]
        public PostUpdatedAdminEvent OnPostUpdated(
            [EventMessage] PostUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public PostDeletedAdminEvent OnPostDeleted(
            [EventMessage] PostDeletedAdminEvent evt) => evt;

        [Subscribe]
        public PostChangedAdminEvent OnPostChanged(
            [EventMessage] PostChangedAdminEvent evt) => evt;
    }
}

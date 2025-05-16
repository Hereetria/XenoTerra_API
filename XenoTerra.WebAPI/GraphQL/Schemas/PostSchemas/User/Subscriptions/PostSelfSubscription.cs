using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class PostSelfSubscription
    {
        [Subscribe]
        public PostCreatedSelfEvent OnPostCreated(
            [EventMessage] PostCreatedSelfEvent evt) => evt;

        [Subscribe]
        public PostUpdatedSelfEvent OnPostUpdated(
            [EventMessage] PostUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public PostDeletedSelfEvent OnPostDeleted(
            [EventMessage] PostDeletedSelfEvent evt) => evt;

        [Subscribe]
        public PostChangedSelfEvent OnPostChanged(
            [EventMessage] PostChangedSelfEvent evt) => evt;
    }
}

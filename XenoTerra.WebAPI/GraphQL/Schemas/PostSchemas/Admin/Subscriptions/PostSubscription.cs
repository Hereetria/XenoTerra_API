using XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.PostSchemas.Admin.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class PostSubscription
    {
        [Subscribe]
        public PostCreatedEvent OnPostCreated(
            [EventMessage] PostCreatedEvent evt) => evt;

        [Subscribe]
        public PostUpdatedEvent OnPostUpdated(
            [EventMessage] PostUpdatedEvent evt) => evt;

        [Subscribe]
        public PostDeletedEvent OnPostDeleted(
            [EventMessage] PostDeletedEvent evt) => evt;

        [Subscribe]
        public PostChangedEvent OnPostChanged(
            [EventMessage] PostChangedEvent evt) => evt;
    }
}

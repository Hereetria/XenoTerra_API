using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.SavedPostSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class SavedPostOwnSubscription
    {
        [Subscribe]
        public SavedPostOwnCreatedEvent OnSavedPostOwnCreated(
            [EventMessage] SavedPostOwnCreatedEvent evt) => evt;

        [Subscribe]
        public SavedPostOwnUpdatedEvent OnSavedPostOwnUpdated(
            [EventMessage] SavedPostOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public SavedPostOwnDeletedEvent OnSavedPostOwnDeleted(
            [EventMessage] SavedPostOwnDeletedEvent evt) => evt;

        [Subscribe]
        public SavedPostOwnChangedEvent OnSavedPostOwnChanged(
            [EventMessage] SavedPostOwnChangedEvent evt) => evt;
    }
}

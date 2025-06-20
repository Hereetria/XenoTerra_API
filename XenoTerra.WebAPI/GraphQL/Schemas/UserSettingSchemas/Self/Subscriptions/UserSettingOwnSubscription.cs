using HotChocolate.Authorization;
using XenoTerra.WebAPI.GraphQL.Auth.Roles;
using XenoTerra.WebAPI.GraphQL.Schemas._RootSubscriptions;
using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    [Authorize(Roles = new[] { nameof(AppRoles.User), nameof(AppRoles.Admin) })]
    public class UserSettingOwnSubscription
    {
        [Subscribe]
        public UserSettingOwnCreatedEvent OnUserSettingOwnCreated(
            [EventMessage] UserSettingOwnCreatedEvent evt) => evt;

        [Subscribe]
        public UserSettingOwnUpdatedEvent OnUserSettingOwnUpdated(
            [EventMessage] UserSettingOwnUpdatedEvent evt) => evt;

        [Subscribe]
        public UserSettingOwnDeletedEvent OnUserSettingOwnDeleted(
            [EventMessage] UserSettingOwnDeletedEvent evt) => evt;

        [Subscribe]
        public UserSettingOwnChangedEvent OnUserSettingOwnChanged(
            [EventMessage] UserSettingOwnChangedEvent evt) => evt;
    }
}

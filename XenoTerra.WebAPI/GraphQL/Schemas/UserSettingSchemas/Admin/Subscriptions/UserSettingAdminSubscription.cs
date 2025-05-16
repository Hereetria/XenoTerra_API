using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class UserSettingAdminSubscription
    {
        [Subscribe]
        public UserSettingCreatedAdminEvent OnUserSettingCreated(
            [EventMessage] UserSettingCreatedAdminEvent evt) => evt;

        [Subscribe]
        public UserSettingUpdatedAdminEvent OnUserSettingUpdated(
            [EventMessage] UserSettingUpdatedAdminEvent evt) => evt;

        [Subscribe]
        public UserSettingDeletedAdminEvent OnUserSettingDeleted(
            [EventMessage] UserSettingDeletedAdminEvent evt) => evt;

        [Subscribe]
        public UserSettingChangedAdminEvent OnUserSettingChanged(
            [EventMessage] UserSettingChangedAdminEvent evt) => evt;
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class UserSettingSelfSubscription
    {
        [Subscribe]
        public UserSettingCreatedSelfEvent OnUserSettingCreated(
            [EventMessage] UserSettingCreatedSelfEvent evt) => evt;

        [Subscribe]
        public UserSettingUpdatedSelfEvent OnUserSettingUpdated(
            [EventMessage] UserSettingUpdatedSelfEvent evt) => evt;

        [Subscribe]
        public UserSettingDeletedSelfEvent OnUserSettingDeleted(
            [EventMessage] UserSettingDeletedSelfEvent evt) => evt;

        [Subscribe]
        public UserSettingChangedSelfEvent OnUserSettingChanged(
            [EventMessage] UserSettingChangedSelfEvent evt) => evt;
    }
}

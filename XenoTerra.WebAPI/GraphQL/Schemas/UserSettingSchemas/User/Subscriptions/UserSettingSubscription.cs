using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions
{
    [ExtendObjectType(typeof(Subscription))]
    public class UserSettingSubscription
    {
        [Subscribe]
        public UserSettingCreatedEvent OnUserSettingCreated(
            [EventMessage] UserSettingCreatedEvent evt) => evt;

        [Subscribe]
        public UserSettingUpdatedEvent OnUserSettingUpdated(
            [EventMessage] UserSettingUpdatedEvent evt) => evt;

        [Subscribe]
        public UserSettingDeletedEvent OnUserSettingDeleted(
            [EventMessage] UserSettingDeletedEvent evt) => evt;

        [Subscribe]
        public UserSettingChangedEvent OnUserSettingChanged(
            [EventMessage] UserSettingChangedEvent evt) => evt;
    }
}

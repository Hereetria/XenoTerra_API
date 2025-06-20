using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events.Types
{
    public class UserSettingOwnChangedEventType : ObjectType<UserSettingOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingOwnChangedEvent> descriptor)
        {
        }
    }
}

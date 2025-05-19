using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events.Types
{
    public class UserSettingSelfChangedEventType : ObjectType<UserSettingSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingSelfChangedEvent> descriptor)
        {
        }
    }
}

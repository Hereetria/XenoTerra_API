using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events.Types
{
    public class UserSettingOwnCreatedEventType : ObjectType<UserSettingOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingOwnCreatedEvent> descriptor)
        {
        }
    }
}

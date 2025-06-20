using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events.Types
{
    public class UserSettingOwnUpdatedEventType : ObjectType<UserSettingOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingOwnUpdatedEvent> descriptor)
        {
        }
    }
}

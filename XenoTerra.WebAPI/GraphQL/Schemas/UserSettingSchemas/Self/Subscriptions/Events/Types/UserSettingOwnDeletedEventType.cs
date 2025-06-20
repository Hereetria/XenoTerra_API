using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events.Types
{
    public class UserSettingOwnDeletedEventType : ObjectType<UserSettingOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingOwnDeletedEvent> descriptor)
        {
        }
    }
}

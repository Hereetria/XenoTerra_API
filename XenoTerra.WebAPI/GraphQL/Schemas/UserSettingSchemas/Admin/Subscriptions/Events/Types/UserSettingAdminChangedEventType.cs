using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions.Events.Types
{
    public class UserSettingAdminChangedEventType : ObjectType<UserSettingAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingAdminChangedEvent> descriptor)
        {
        }
    }
}

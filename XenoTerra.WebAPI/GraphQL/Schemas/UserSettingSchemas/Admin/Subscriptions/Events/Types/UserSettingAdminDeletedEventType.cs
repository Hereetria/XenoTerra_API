using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions.Events.Types
{
    public class UserSettingAdminDeletedEventType : ObjectType<UserSettingAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingAdminDeletedEvent> descriptor)
        {
        }
    }
}

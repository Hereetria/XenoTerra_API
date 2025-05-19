using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions.Events.Types
{
    public class UserSettingAdminUpdatedEventType : ObjectType<UserSettingAdminUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingAdminUpdatedEvent> descriptor)
        {
        }
    }
}

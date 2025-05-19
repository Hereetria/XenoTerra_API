using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Admin.Subscriptions.Events.Types
{
    public class UserSettingAdminCreatedEventType : ObjectType<UserSettingAdminCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingAdminCreatedEvent> descriptor)
        {
        }
    }
}

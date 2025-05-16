namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions.Events.Types
{
    public class UserSettingCreatedEventType : ObjectType<UserSettingCreatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingCreatedAdminEvent> descriptor)
        {
        }
    }
}

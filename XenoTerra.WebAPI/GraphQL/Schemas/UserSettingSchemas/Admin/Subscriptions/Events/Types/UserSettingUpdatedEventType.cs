namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions.Events.Types
{
    public class UserSettingUpdatedEventType : ObjectType<UserSettingUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingUpdatedAdminEvent> descriptor)
        {
        }
    }
}

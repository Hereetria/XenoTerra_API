namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions.Events.Types
{
    public class UserSettingChangedEventType : ObjectType<UserSettingChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingChangedAdminEvent> descriptor)
        {
        }
    }
}

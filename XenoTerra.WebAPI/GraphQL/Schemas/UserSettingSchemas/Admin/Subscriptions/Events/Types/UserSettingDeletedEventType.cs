namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions.Events.Types
{
    public class UserSettingDeletedEventType : ObjectType<UserSettingDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingDeletedAdminEvent> descriptor)
        {
        }
    }
}

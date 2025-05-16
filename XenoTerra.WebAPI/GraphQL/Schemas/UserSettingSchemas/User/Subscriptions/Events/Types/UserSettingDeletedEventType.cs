namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions.Events.Types
{
    public class UserSettingDeletedEventType : ObjectType<UserSettingDeletedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingDeletedSelfEvent> descriptor)
        {
        }
    }
}

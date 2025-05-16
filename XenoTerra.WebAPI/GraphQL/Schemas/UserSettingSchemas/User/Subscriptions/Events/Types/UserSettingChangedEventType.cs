namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions.Events.Types
{
    public class UserSettingChangedEventType : ObjectType<UserSettingChangedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingChangedSelfEvent> descriptor)
        {
        }
    }
}

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions.Events.Types
{
    public class UserSettingUpdatedEventType : ObjectType<UserSettingUpdatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingUpdatedSelfEvent> descriptor)
        {
        }
    }
}

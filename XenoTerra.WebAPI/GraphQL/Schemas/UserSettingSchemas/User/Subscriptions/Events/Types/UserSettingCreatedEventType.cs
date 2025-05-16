namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Subscriptions.Events.Types
{
    public class UserSettingCreatedEventType : ObjectType<UserSettingCreatedSelfEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingCreatedSelfEvent> descriptor)
        {
        }
    }
}

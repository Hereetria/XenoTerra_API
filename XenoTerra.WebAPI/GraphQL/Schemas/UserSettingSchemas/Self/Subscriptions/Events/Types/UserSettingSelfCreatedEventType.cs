using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events.Types
{
    public class UserSettingSelfCreatedEventType : ObjectType<UserSettingSelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingSelfCreatedEvent> descriptor)
        {
        }
    }
}

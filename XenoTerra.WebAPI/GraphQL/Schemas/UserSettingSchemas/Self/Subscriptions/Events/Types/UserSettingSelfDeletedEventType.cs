using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events.Types
{
    public class UserSettingSelfDeletedEventType : ObjectType<UserSettingSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingSelfDeletedEvent> descriptor)
        {
        }
    }
}

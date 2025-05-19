using XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSettingSchemas.Self.Subscriptions.Events.Types
{
    public class UserSettingSelfUpdatedEventType : ObjectType<UserSettingSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSettingSelfUpdatedEvent> descriptor)
        {
        }
    }
}

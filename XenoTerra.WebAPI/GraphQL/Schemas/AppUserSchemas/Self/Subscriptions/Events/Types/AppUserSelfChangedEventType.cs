using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events.Types
{
    public class AppUserSelfChangedEventType : ObjectType<UserSelfChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSelfChangedEvent> descriptor)
        {
        }
    }
}

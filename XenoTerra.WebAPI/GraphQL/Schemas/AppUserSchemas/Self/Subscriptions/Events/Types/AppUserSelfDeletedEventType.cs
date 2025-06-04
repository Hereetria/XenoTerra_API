using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events.Types
{
    public class AppUserSelfDeletedEventType : ObjectType<UserSelfDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSelfDeletedEvent> descriptor)
        {
        }
    }
}

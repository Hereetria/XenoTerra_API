using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events.Types
{
    public class AppUserSelfCreatedEventType : ObjectType<UserSelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSelfCreatedEvent> descriptor)
        {
        }
    }
}

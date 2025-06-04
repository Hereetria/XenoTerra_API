using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events.Types
{
    public class AppUserSelfUpdatedEventType : ObjectType<UserSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSelfUpdatedEvent> descriptor)
        {
        }
    }
}

using XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.AppUserSchemas.Self.Subscriptions.Events.Types
{
    public class AppUserOwnCreatedEventType : ObjectType<UserOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserOwnCreatedEvent> descriptor)
        {
        }
    }
}

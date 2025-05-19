using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Subscriptions.Events.Types
{
    public class UserSelfCreatedEventType : ObjectType<UserSelfCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSelfCreatedEvent> descriptor)
        {
        }
    }
}

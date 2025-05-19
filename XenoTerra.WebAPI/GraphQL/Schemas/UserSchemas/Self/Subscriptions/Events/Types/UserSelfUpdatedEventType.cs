using XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserSchemas.Self.Subscriptions.Events.Types
{
    public class UserSelfUpdatedEventType : ObjectType<UserSelfUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserSelfUpdatedEvent> descriptor)
        {
        }
    }
}

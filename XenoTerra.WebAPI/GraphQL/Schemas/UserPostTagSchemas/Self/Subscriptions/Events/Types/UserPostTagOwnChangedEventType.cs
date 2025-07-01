using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Subscriptions.Events.Types
{
    public class UserPostTagOwnChangedEventType : ObjectType<UserPostTagOwnChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagOwnChangedEvent> descriptor)
        {
        }
    }
}

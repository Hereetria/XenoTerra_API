using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Subscriptions.Events.Types
{
    public class UserPostTagOwnCreatedEventType : ObjectType<UserPostTagOwnCreatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagOwnCreatedEvent> descriptor)
        {
        }
    }
}

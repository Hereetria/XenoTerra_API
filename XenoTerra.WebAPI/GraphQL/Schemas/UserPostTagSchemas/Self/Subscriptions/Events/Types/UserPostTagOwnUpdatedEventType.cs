using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Subscriptions.Events.Types
{
    public class UserPostTagOwnUpdatedEventType : ObjectType<UserPostTagOwnUpdatedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagOwnUpdatedEvent> descriptor)
        {
        }
    }
}

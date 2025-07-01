using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Self.Subscriptions.Events.Types
{
    public class UserPostTagOwnDeletedEventType : ObjectType<UserPostTagOwnDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagOwnDeletedEvent> descriptor)
        {
        }
    }
}

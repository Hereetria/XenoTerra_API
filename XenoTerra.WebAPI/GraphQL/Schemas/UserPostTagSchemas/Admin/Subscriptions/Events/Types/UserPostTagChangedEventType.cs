using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagChangedEventType : ObjectType<UserPostTagChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagChangedEvent> descriptor)
        {
        }
    }
}

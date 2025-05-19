using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagAdminChangedEventType : ObjectType<UserPostTagAdminChangedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagAdminChangedEvent> descriptor)
        {
        }
    }
}

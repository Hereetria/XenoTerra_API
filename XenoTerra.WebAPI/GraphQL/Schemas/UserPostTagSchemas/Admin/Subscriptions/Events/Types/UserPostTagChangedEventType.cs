using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagChangedEventType : ObjectType<UserPostTagChangedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagChangedAdminEvent> descriptor)
        {
        }
    }
}

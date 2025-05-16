using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagDeletedEventType : ObjectType<UserPostTagDeletedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagDeletedAdminEvent> descriptor)
        {
        }
    }
}

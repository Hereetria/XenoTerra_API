using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagAdminDeletedEventType : ObjectType<UserPostTagAdminDeletedEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagAdminDeletedEvent> descriptor)
        {
        }
    }
}

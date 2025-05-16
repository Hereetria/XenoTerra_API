using XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events;

namespace XenoTerra.WebAPI.GraphQL.Schemas.UserPostTagSchemas.Admin.Subscriptions.Events.Types
{
    public class UserPostTagUpdatedEventType : ObjectType<UserPostTagUpdatedAdminEvent>
    {
        protected override void Configure(IObjectTypeDescriptor<UserPostTagUpdatedAdminEvent> descriptor)
        {
        }
    }
}
